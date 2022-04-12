using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject guideBox;

    public Text guideText;

    [TextArea(3,10)]
    public string guide;

    public bool inRange;

    private void Start()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            guideBox.SetActive(true);

            guideText.text = guide;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            guideBox.SetActive(false);
        }
    }
}
