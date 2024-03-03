using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockState : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
