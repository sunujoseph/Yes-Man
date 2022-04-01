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

        var dir = target.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        

        arrowRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject,2);

        

    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            collision.gameObject.GetComponent<PlayerControl>().TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }

}
