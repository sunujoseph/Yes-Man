using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public bool inBuyZone;

    public int playerGold;
    public int itemPrice;

    GameObject player;

    public GameObject buyMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Store.instance.isShopping == true)
        {
            Debug.Log("Shopping Up");
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                
                buyMessage.SetActive(true);
                inBuyZone = true;

            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        buyMessage.SetActive(false);
        inBuyZone = false;
    }

    private void Update()
    {
        CheckPlayerGold();
        if (Input.GetKeyDown(KeyCode.B))
        {
            Buy();
        }
    }
    void CheckPlayerGold()
    {
        player = GameObject.FindWithTag("Player");
        playerGold = player.GetComponent<PlayerControl>().CheckGold();
    }

    
    
    public void Buy()
    {
        
        if (inBuyZone && playerGold >= itemPrice)
        {
            Debug.Log("Bought");
            gameObject.GetComponent<Powerup>().StoreItem();

            player.GetComponent<PlayerControl>().SpendGold(itemPrice);

        }

        else if (inBuyZone && playerGold < itemPrice)
        {
            Debug.Log("YOU ARE BROKE... GET SOME MORE GOLD!");
        }
    }
            
       
}
