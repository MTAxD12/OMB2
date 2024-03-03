using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI TimerText;
    public bool shouldCountTime;
    public static float t;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            shouldCountTime = true;
        }
        else
        {
            shouldCountTime = false;
            t = 0;
        }
    }
    void Update()
    {
        if (shouldCountTime)
        {
            t += Time.deltaTime;
        }
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TimerText.text = minutes + ":" + seconds;
    }
}