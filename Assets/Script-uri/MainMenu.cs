using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public static bool isHardcore = false;


    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		isHardcore = false;
	}
	
	public void PlayHardcore()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		isHardcore = true;
	}
}
