using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer wand;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
            wand.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        wand.GetComponent<SpriteRenderer>().enabled = true;
    }
}
