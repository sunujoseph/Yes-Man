using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : Enemy
{


    public GameObject arrows;
    public GameObject arrowParent;
    public float arrowForce = 5f;

    public float arrowSpeed;
    public float firerate;
    public float nextShootTime;

    public float range;

 


    private void FixedUpdate()
    {
        MoveTowardPlayer();
        LookTowardPlayer();
    }

    
    public override void MoveTowardPlayer()
    {
        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);


        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, ( speed * Time.deltaTime));
        }
        else if (distanceFromPlayer <= range && nextShootTime < Time.time)
        {
            Shoot();

            nextShootTime = Time.time + firerate;
        }
    }

    public override void LookTowardPlayer()
    {
        base.LookTowardPlayer();
    }


    void Shoot()
    {

        Instantiate(arrows, arrowParent.transform.position, Quaternion.identity);
        GameObject bullet = Instantiate(arrows, arrowParent.transform.position, arrowParent.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(arrowParent.transform.up * arrowForce, ForceMode2D.Impulse);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
