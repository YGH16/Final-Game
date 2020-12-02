using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;

    public LineRenderer sightLine;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * UnityEngine.Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        UnityEngine.Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        sightLine.SetPosition(1, hitInfo.point);

        if (hitInfo.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("Wasted");
        }


        sightLine.SetPosition(0, transform.position);

    }
}
