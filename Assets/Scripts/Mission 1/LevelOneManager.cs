using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    public bool Paper = false;
    public bool Key = false;

    public void PickupPaper()
    {
        Paper = true;
    }
    public void PickupKey()
    {
        Key = true;
    }
}
