using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PushDown : MonoBehaviour
{
    public GameObject RestartButton;
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            RestartButton.SetActive(true);
        }
        
    }
}
