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

    private Transform target;

    

    private void Start()
    {
        _dasherRB = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    private void FixedUpdate()
    {
        MoveTowardPlayer();
        LookTowardPlayer();
    }


    public override void MoveTowardPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(target.transform.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * Time.deltaTime));
        }
          
        if (distanceFromPlayer <= dashRange )
        {
            direction = target.transform.position - transform.position;

            if (nextDashCounter < Time.time)
            {

                _dasherRB.AddForce(new Vector2(direction.x, direction.y), ForceMode2D.Impulse);

                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (dashSpeed * Time.deltaTime));

                nextDashCounter = Time.time + dashRate;
                
            }
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * Time.deltaTime));

        }

    }

    public override void LookTowardPlayer()
    {
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, dashRange);
    }
}
