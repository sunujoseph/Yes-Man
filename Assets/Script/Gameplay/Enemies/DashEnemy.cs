using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : Enemy
{

    public Rigidbody2D _dasherRB;

    public float dashRange;
    public float dashRate;

    public float startDashTimer;
    float currentDashTimer; 


    public float dashSpeed = 1;

    bool isDashing = true; 

    public Transform target;

    private void Start()
    {
        _dasherRB = GetComponent<Rigidbody2D>();

    }

    

    private void FixedUpdate()
    {
        MoveTowardPlayer();
        LookTowardPlayer();
    }


    public override void MoveTowardPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (distanceFromPlayer <= lineOfSite && distanceFromPlayer > dashRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        }

        if (distanceFromPlayer <= dashRange)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;

            Dashing();

        }

    }


    void Dashing()
    {
        if (isDashing)
        {
            _dasherRB.AddForce(direction * 2 * speed);
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <=0)
            {
                isDashing = false;

                _dasherRB.AddForce(direction * speed);
            }
        }
       
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, dashRange);
    }
}
