using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
	public void startGame()
    {
		SceneManager.LoadScene(1);
    }

	//Attach button to script to options script
	public void quitGame()
	{
		Application.Quit();
	}

	public void restartGame()
	{
		SceneManager.LoadScene(1);
	}
	public void loadRestartGame()
	{
		SceneManager.LoadScene(2);
	}
}
