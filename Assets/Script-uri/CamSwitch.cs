using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;


    public void SchimbareCameraIncSf()
        {
            cam1.SetActive(false);
            cam2.SetActive(true);

        }
    }