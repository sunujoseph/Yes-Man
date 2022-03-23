using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    
    Rigidbody2D arrowRB;
    public GameObject target;
    public float arrowSpeed;

    public float damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");
        arrowRB = GetComponent<Rigidbody2D>();
        Vector2 moveDir = (target.transform.position - transform.position).normalized * arrowSpeed;
        arrowRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject,2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerControl>().TakeDamage(damage);

            Destroy(this.gameObject);
        }
        
    }

}
