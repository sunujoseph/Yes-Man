using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl instance;

    public Text _playerHPText; 
    public Text _playerManaText;

    public Text _currentGoldText;

    void Awake()
    {
        instance = this;
        
    }

    

}
