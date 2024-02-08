using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private Game gameBoard;
    private Ball ball; // Reference to the Ball script
    private Paddle Lpaddle;
    private Paddle Rpaddle;
    public GameObject gameAudio;
    public CameraShake CameraShake;

    void Start() {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        Lpaddle = GameObject.FindWithTag("LeftPaddle").GetComponent<Paddle>();
        Rpaddle = GameObject.FindWithTag("RightPaddle").GetComponent<Paddle>();
        gameBoard = GameObject.FindGameObjectWithTag("Finish").GetComponent<Game>();
        gameBoard.right = 0;
        gameBoard.left = 0;
    }

    void launcheBallForward() { ball.LaunchBall("forward"); }
    void launcheBallBackwards() { ball.LaunchBall("backwards"); }
    

    public void OnTriggerEnter(Collider other)
    {
        
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioSource source = gameAudio.GetComponent<AudioSource>();

        if (gameObject.name == "Left Goal")
        {
            source.Stop();
            audioSource.Play();
            gameBoard.right = gameBoard.right + 1;
            gameBoard.rightGameScore();
            source.PlayDelayed(2);
            if (gameBoard.right == 11) {
                Debug.Log($"Game Over! Right Paddle Wins !");
                CameraShake.ShakeCamera();
                source.Stop();
                gameBoard.scoreRest();
                ball.BallReset();
            }
            else if (gameBoard.right <= 10) {
                ball.BallReset();
                Lpaddle.paddleReset();
                Rpaddle.paddleReset();
                Invoke("launcheBallForward", 2);
            }
           
        }
        else if (gameObject.name == "Right Goal") {
            source.Stop();
            audioSource.Play();
            gameBoard.left = gameBoard.left + 1;
            gameBoard.leftGameScore();
            source.PlayDelayed(2);

            if (gameBoard.left == 11) {
                Debug.Log($"Game Over! Left Paddle Wins !");
                CameraShake.ShakeCamera();
                source.Stop();
                gameBoard.scoreRest();
                ball.BallReset();
            }
            else if (gameBoard.left <= 10)
            {
                ball.BallReset();
                Lpaddle.paddleReset();
                Rpaddle.paddleReset();
                Invoke("launcheBallBackwards", 2);
            }
            
        }
        
    }



}
