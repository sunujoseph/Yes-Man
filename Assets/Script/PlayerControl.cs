using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    //Components
    public Rigidbody2D rb;
    public Camera cam;

    // Player
    public float moveSpeed = 5f;
    Vector2 movement;
    Vector2 mousePos;

    //private Vector3 moveDelta;
    //public float _speed;

    private float _currentHP;
    private float _maxHP = 100;

 
    public Text playerHPDisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        StartHP();
        Debug.Log(_currentHP);
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        DisplayHealth();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Mousae position. player faces mouse position
        // diagonal movement should be the same speed as vertical 
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

        //moveDelta = new Vector3(x,y,0);

        //transform.Translate(moveDelta * _speed * Time.deltaTime);
    }

    void StartHP()
    {
        _currentHP = _maxHP; 
    }

    void TakeDamage(float dmg)
    {
        _currentHP -= dmg; 
    }

    void DisplayHealth()
    {
        if (playerHPDisplay != null)
        {
            //Display current HP
            playerHPDisplay.text = _currentHP.ToString();
        }


    }
    

}
