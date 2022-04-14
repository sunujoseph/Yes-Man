using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Camera cam;
    public GameObject player;
    public Animator animator;
    public AudioSource sources;

    Vector2 _movement;
    Vector2 mousePosition;

    public float _speed;
    float startingSpeed;

    public float _currentHP = 100.0f;
    private float _maxHP = 100.0f;
    float starting_maxHP;

    public float _currentMana = 100.0f;
    private float _maxMana = 100.0f;

    public int currentGold;
    int deathline;
    int number;

    public GameObject _hpFill;
    public GameObject _manaFill;

    public bool isDead = false;
    public bool invincibleDash = false;
    bool isDashing = false;

    //for Dash
    private float activeMoveSpeed;
    public float dashSpeed;
    float startingDashSpeed;

    public float dashLength = 0.5f;
    public float dashCooldown = 1f;
    float startingDashCooldown;

    private float dashCounter;
    private float dashCoolCounter;

    Powerup currentSelectedPowerup;

    [SerializeField] FlashImage _flashImage;

    public List<GameObject> itemsToDrop = new List<GameObject>();
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

        startingDashCooldown = dashCooldown;

        startingDashSpeed = dashSpeed;

        startingSpeed = _speed;

        starting_maxHP = _maxHP;

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
        DisplayGold();

        ActivatePowerup();
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
                isDashing = true;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                animator.SetBool("isDash", true);
                isDashing = false;
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
        if (!invincibleDash || !isDashing)
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
            sources.Play();
            _currentHP = 0.0f;
            isDead = true;
            player.SetActive(false);
            
            SceneManager.LoadScene(4);
            
            //Destroy(gameObject);


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
        if (currentGold >= 10)
        {
            Shooping();

        }
    } 


    //Powerups

    void ActivatePowerup()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentSelectedPowerup.UsePowerup();
        }
    }
    public void DecreaseDashCooldown(float cooldownMultiplier)
    {
        dashCooldown = startingDashCooldown * cooldownMultiplier;
    }
    public void RevertDashCooldown()
    {
        dashCooldown = startingDashCooldown;
    }

    public void IncreaseDashSpeed(float dashSpeedMultiplier)
    {
        dashSpeed = startingDashSpeed * dashSpeedMultiplier;
    }
    public void RevertDashSpeed()
    {
        dashSpeed = startingDashSpeed;
    }
    public void IncreaseMaxHP(float maxHP_Multiplier)
    {
        _maxHP = starting_maxHP * maxHP_Multiplier;
        _currentHP = _maxHP;
    }
    public void RevertMaxHP()
    {
        _maxHP = starting_maxHP;
        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
    }

    public void SetInvincibleDash()
    {
        invincibleDash = true;
    }
    public void RevertInvincibilty()
    {
        invincibleDash = false;
    }

    public void IncreaseSpeed(float speedMultiplier)
    {
        _speed = startingSpeed * speedMultiplier;
    }
    public void RevertSpeed()
    {
        _speed = startingSpeed;
    }
    public void Shooping()
    {
        currentGold -= 10;
        float randomItem = Random.Range(0, itemsToDrop.Count);
        int itemKey = Mathf.RoundToInt(randomItem);

        Instantiate(itemsToDrop[itemKey], transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
