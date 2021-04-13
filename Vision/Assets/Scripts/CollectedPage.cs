using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPage : MonoBehaviour
{
    [SerializeField] private Collider2D playerCheck;
    [SerializeField] private LayerMask playerLayers;
    
    public GameManager gameManager;

    private void OnTriggerEnter2D()
    {
        gameManager.GotPage();
    }
    
    private void Update()
    {
        if (playerCheck.IsTouchingLayers(playerLayers))
        {
            Destroy(gameObject);
        }
    }
}
