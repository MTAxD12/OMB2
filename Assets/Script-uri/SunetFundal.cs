using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunetFundal : MonoBehaviour
{
    private static SunetFundal _instace;
    private static bool musicIsStopped;

    void Start()
    {
        if (_instace && _instace != this)
        {
            Destroy(this.gameObject);
            return;
        }
            DontDestroyOnLoad(this.gameObject);
            _instace = this;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 0 && scene.buildIndex <= 8)
		{
            StartMuzica();
		}
		else
		{
            StopMuzica();
		}
    }

    public void StopMuzica()
	{
        gameObject.GetComponent<AudioSource>().Stop();
        musicIsStopped = true;
        
	}

    public void PauseMenuMuzica()
	{
        gameObject.GetComponent<AudioSource>().volume = 0.1f;
    }

    public void StartMuzica()
	{
        if(musicIsStopped == true)
		{
            gameObject.GetComponent<AudioSource>().Play();
            musicIsStopped = false;
		}
        gameObject.GetComponent<AudioSource>().volume = 0.4f;

	}

    public void SfarsitNivel()
	{
        gameObject.GetComponent<AudioSource>().volume = 0.2f;
	}

}
