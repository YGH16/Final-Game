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

	//Attach button to script to options script - option menu
	public void quitGame()
	{
		Application.Quit();
	}

	public void MainMenu()
    {
		SceneManager.LoadScene(0);
    }
	
	public void missionOne()
	{
		SceneManager.LoadScene(5);
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
