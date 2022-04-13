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

    public Text _roundTimer;
    public Text _currentRound;

    IDictionary<string, string> powerupInfo = new Dictionary<string, string>();
    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        powerupInfo.Add("Amplyfying Gem", "description");
        powerupInfo.Add("Bottle of Whispers", "description");
        powerupInfo.Add("Goblin's Satchel", "description");
        powerupInfo.Add("Potion of HP", "description");
        powerupInfo.Add("Naga's Tonic", "description");
        powerupInfo.Add("Shadowy Cloak", "description");
        powerupInfo.Add("Sweet Ass Kicks", "description");
        powerupInfo.Add("Warriors Heart", "description");
    }



}
