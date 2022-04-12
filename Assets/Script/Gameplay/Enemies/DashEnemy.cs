using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : Enemy
{

    Rigidbody2D _dasherRB;

    public float dashRange;
    public float dashRate;
    public float nextDashCounter;

    public float dashSpeed = 1; 

    
    public Transform target; 

    private void Start()
    {
        _dasherRB = GetComponent<Rigidbody2D>();
        
    }


    private void FixedUpdate()
    {
        MoveTowardPlayer();
        
    }


    public override void MoveTowardPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        }
          
        if (distanceFromPlayer <= dashRange )
        {
            direction = player.transform.position - transform.position;

            if (nextDashCounter < Time.time)
            {

                _dasherRB.AddForce(new Vector2(direction.x, direction.y), ForceMode2D.Impulse);

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (dashSpeed * Time.deltaTime));

                nextDashCounter = Time.time + dashRate;
                
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));

        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, dashRange);
    }
}
