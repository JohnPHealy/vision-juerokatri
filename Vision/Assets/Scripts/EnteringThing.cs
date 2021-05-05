using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringThing : MonoBehaviour
{
    public GameObject DialogueManager1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Activate the canvas
            DialogueManager1.SetActive(true);
        }
    }
}
