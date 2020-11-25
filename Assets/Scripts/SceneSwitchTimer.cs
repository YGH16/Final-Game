using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTimer : MonoBehaviour
{
    public float Time;
    public int Scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(Time));
    }

    IEnumerator LoadSceneAfterDelay(float Time)
    {
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene(Scene);
    }
}