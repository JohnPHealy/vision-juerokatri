using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringThing : MonoBehaviour
{
    public GameObject DialogueManager1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the object has the tag car
        if(other.tag == "Player")
        {
            //Activate the canvas
            DialogueManager1.SetActive(true);
        }
    }
}
