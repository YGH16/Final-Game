using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI Objective2;

    private void OnTriggerEnter2D(Collider2D key)
    {
        LevelOneManager manager = key.GetComponent<LevelOneManager>();
        if (manager)
        {
            manager.PickupKey();
            gameObject.SetActive(false);
            Objective2.text = "- Find the Key to Unlock the Door - DONE";
        }
    }
}
