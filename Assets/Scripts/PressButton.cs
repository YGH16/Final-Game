using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{

    [SerializeField]

    private Text hitSpacebarText;

    private bool buttonPressAvaialble;

    private void Start()
    {
        hitSpacebarText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(buttonPressAvaialble && Input.GetKeyDown(KeyCode.Space))
        {
            buttonPress();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            hitSpacebarText.gameObject.SetActive(true);
            buttonPressAvaialble = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            hitSpacebarText.gameObject.SetActive(false);
            buttonPressAvaialble = false;
        }
    }

    private void buttonPress()
    {
        Destroy(gameObject);
    }
}
