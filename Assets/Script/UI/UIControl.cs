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
    public Text _timeLeft;
    public Text _currentRound;


    public Text ampGemAmountText, bottleAmountText, goblinAmountText, nagaAmountText, potionAmountText, cloakAmountText, shoesAmountText, heartAmountText;
    void Awake()
    {
        instance = this;
        
        
    }

    

    
}
