using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Paper : MonoBehaviour
{
    public TextMeshProUGUI Objective1;

    private void OnTriggerEnter2D(Collider2D key)
    {
        LevelOneManager manager = key.GetComponent<LevelOneManager>();
        if (manager)
        {
            manager.PickupKey();
            gameObject.SetActive(false);
            Objective1.text = "- Find the Secret Files - DONE";
        }
    }
}
