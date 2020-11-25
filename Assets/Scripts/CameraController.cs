using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	 public GameObject player;
	 
	 private Vector3 offset;
	 
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Called After Each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
