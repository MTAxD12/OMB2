using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _fpsText;
    public GameObject FPS_Text;
    [SerializeField] private float _hudRefreshRate = 0.1f;

    public GameObject PPV;

    private float _timer;

    public static bool fpsIsOn = false;

    private void Start()
    {
        if (fpsIsOn == true)
        {
            FPS_Text.SetActive(true);
            fpsIsOn = true;
        }
        Application.targetFrameRate = 144;
    }

    void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = fps.ToString();
            _timer = Time.unscaledTime + _hudRefreshRate;
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (fpsIsOn == false)
            {
                FPS_Text.SetActive(true);
                fpsIsOn = true;
            }
            else
            {
                FPS_Text.SetActive(false);
                fpsIsOn = false;
            }
        }

        if (PlayerPrefs.GetInt("qualityLevel") == 4)
        {
            PPV.SetActive(true);
        }
        else
        {
            PPV.SetActive(false);
        }
    }
}
