using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Camera cam;
    public GameObject player;


    Vector2 _movement;
    Vector2 mousePosition;

    public float _speed;
    public float _currentHP = 100.0f;
    private float _maxHP = 100.0f;

    public bool isDead = false;

    //for Dash
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private void Awake()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        StartHP();
    }


    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = _speed;
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        Dash();

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        DisplayHealth();

        Die();
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * activeMoveSpeed * Time.deltaTime);

        LookAtDir();
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = _speed;
                dashCoolCounter = dashCooldown; 
            }   
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
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
        //UIControl.instance.playerHPText.text = _currentHP.ToString();
       // UIControl.instance._healthSlider.value = _currentHP;
        //UIControl.instance._healthSlider.maxValue = _maxHP;
    }

    public void TakeDamage(float dmg)
    {
        _currentHP -= dmg; 
    }

    public void HealDamage(float heal)
    {
        _currentHP += heal;
            if (_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }
    }

    public void Die()
    {
        if (_currentHP <= 0.0f && !isDead)
        {

            _currentHP = 0.0f;
            isDead = true;

            Destroy(gameObject);


        }
    }

    void DisplayHealth()
    {       
        //UIControl.instance.playerHPText.text = _currentHP.ToString();
        //UIControl.instance._healthSlider.value = _currentHP;
    }
   
}
