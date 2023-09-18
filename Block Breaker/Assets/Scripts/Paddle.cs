using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits =16f;

    //cached refs
    GameSession gameSession;
    Ball ball;
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;


    }


    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else 
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
