using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    private Vector3 moveDelta;
    public float _speed;

    private float _currentHP;
    private float _maxHP = 100;

 
    public Text playerHPDisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        StartHP();
        Debug.Log(_currentHP);
    }

    private void Update()
    {
        DisplayHealth();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x,y,0);

        transform.Translate(moveDelta * _speed * Time.deltaTime);
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
