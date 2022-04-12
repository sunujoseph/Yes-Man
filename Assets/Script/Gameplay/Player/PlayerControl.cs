using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Camera cam;
    public GameObject player;
    public Animator animator;


    Vector2 _movement;
    Vector2 mousePosition;

   
    public float _speed;

    public float _currentHP = 100.0f;
    private float _maxHP = 100.0f;

    public float _currentMana = 100.0f;
    private float _maxMana = 100.0f;

    public int currentGold;

    public GameObject _hpFill;
    public GameObject _manaFill;

    public bool isDead = false;

    //for Dash
    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;


    [SerializeField] FlashImage _flashImage;

    private void Awake()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

       
    }


    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = _speed;
        StartHP();
        StartMana();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        Dash();

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        DisplayHealth();
        DisplayMana();

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
                animator.SetBool("isDash", true);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = _speed;
                dashCoolCounter = dashCooldown;
                animator.SetBool("isDash", false);
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
        UIControl.instance._playerHPText.text = _currentHP.ToString();
        

    }void StartMana()
    {
        _currentMana = _maxMana;
        UIControl.instance._playerHPText.text = _currentMana.ToString();
       

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
        UIControl.instance._playerHPText.text = _currentHP.ToString();
        _hpFill.GetComponent<RectTransform>().sizeDelta = new Vector2(170.0f * (_currentHP / 100.0f), 25);
        

    }
    void DisplayMana()
    {
        UIControl.instance._playerManaText.text = _currentMana.ToString();
        _manaFill.GetComponent<RectTransform>().sizeDelta = new Vector2(170.0f * (_currentMana / 100.0f), 25);

    }

    void DisplayGold()
    {
        UIControl.instance._currentGoldText.text = currentGold.ToString();
    }

    public void AddGold(int goldValue)
    {
        currentGold += goldValue;
    }
}
