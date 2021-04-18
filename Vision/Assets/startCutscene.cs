using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCutsceneOn = true;
            camAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        camAnim.SetBool("cutscene1", false);
        isCutsceneOn = false;
        Destroy(gameObject);
    }
}
