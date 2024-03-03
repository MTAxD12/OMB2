using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TriggerTimer : MonoBehaviour
{

    public TextMeshProUGUI TimerFinal;
    public static float timpFinal;


    private void Start()
    {
        timpFinal = Timer.t;
        Debug.Log(timpFinal);
        string minutes = ((int)timpFinal / 60).ToString();
        string seconds = (timpFinal % 60).ToString("f2");
        TimerFinal.text = "Time " + minutes + ":" + seconds;

    }
}