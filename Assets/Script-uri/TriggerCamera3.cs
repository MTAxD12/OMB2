using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera3 : MonoBehaviour
{
    public GameObject camera2;
    public GameObject camera3;

    void OnTriggerEnter()
    {
        camera2.SetActive(false);
        camera3.SetActive(true);
    }
}
