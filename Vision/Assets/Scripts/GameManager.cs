using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> addScore;
    private Vector3 startPos;
    private int score;
    public GameObject CompleteLevelUI;
    public GameObject GotPageUI;

    private void Start()
    {
        startPos = player.transform.position;
        score = 0;
        UpdateUI();
        UnpauseGame();
    }

    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        score = 0;
        UpdateUI();
    }

    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        UpdateUI();
    }

    private void UpdateUI()
    {
        addScore.Invoke(score.ToString());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }

    public void GotPage()
    {
        GotPageUI.SetActive(true);
    }
}