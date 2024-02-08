using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float unitsPerSecond = 500f;
    private Vector3 paddlePos;
    private Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        paddlePos = rb.position;

    }

    
    void FixedUpdate() {
        GameObject leftPaddle = GameObject.FindGameObjectWithTag("LeftPaddle");
        GameObject rightPaddle = GameObject.FindGameObjectWithTag("RightPaddle");
        
        
        if (leftPaddle ) {
            float horValueL = Input.GetAxis("HorizontalL");
            Vector3 forceL = Vector3.right * horValueL* unitsPerSecond * Time.deltaTime;
            Rigidbody rbL = leftPaddle.GetComponent<Rigidbody>();
            rbL.AddForce(forceL, ForceMode.Force);
        }

        if (rightPaddle) {
            float horValueR = Input.GetAxis("HorizontalR");
            Vector3 forceR = Vector3.left * horValueR * unitsPerSecond * Time.deltaTime;
            Rigidbody rbR =rightPaddle.GetComponent<Rigidbody>();
            rbR.AddForce(forceR, ForceMode.Force);
        }
    }

    public void paddleReset() {   
        rb.position = paddlePos;
        rb.velocity = Vector3.zero;
        
    }
    
   
}
