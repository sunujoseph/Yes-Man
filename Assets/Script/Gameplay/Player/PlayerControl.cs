using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Camera cam;

    Vector2 _movement;
    Vector2 mousePosition;
    public float _speed;
  


    private float _currentHP;
    private float _maxHP = 100f;

 
    public Text playerHPDisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        StartHP();
        Debug.Log(_currentHP);
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        DisplayHealth();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.deltaTime);

        LookAtDir();
    }

    void LookAtDir()
    {

        Vector2 lookAtDir = mousePosition - _rb.position;

        float angle = Mathf.Atan2(lookAtDir.y, lookAtDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
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
