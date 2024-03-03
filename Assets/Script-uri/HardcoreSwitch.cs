using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardcoreSwitch : MonoBehaviour
{
	private static int n;

	private void Start()
	{
		if (MainMenu.isHardcore == true)
		{
			n = PlayerPrefs.GetInt("HighscoreHardcore", n);
			Destroy(this.GetComponent<Ciocnire>());
			gameObject.GetComponent<CiocnireHardcore>().enabled = true;
			if (SceneManager.GetActiveScene().buildIndex > n) {
				n = SceneManager.GetActiveScene().buildIndex - 1;
			}
			PlayerPrefs.SetInt("HighscoreHardcore", n);
			Debug.Log("n=" + n);
		}
		else
		{
			Destroy(this.GetComponent<CiocnireHardcore>());
			gameObject.GetComponent<Ciocnire>().enabled = true;
		}
	}

}
