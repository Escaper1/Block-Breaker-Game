﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{   //config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 24;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;

    private void Awake()
    {

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;


        if (gameStatusCount > 1) { 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
                else
                {
                   DontDestroyOnLoad(gameObject);
                }
    }
    private void Start()
    { 
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        

        
        if (Input.GetMouseButton(1))
            Time.timeScale = 2*gameSpeed;
        else 
        Time.timeScale = gameSpeed;
    }
   

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }


    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
