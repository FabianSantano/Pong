using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector3 ballPos;
    private Rigidbody rb;

    private float speedMultiplier = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        ballPos = rb.position;
        LaunchBall("forward");
    }

    public void LaunchBall(string direction) {
        if (direction == "backwards") {
            
            Quaternion rotate = Quaternion.Euler(0f, 60f, 0f);
            Vector3 bounceDir = rotate * Vector3.back;
            rb.AddForce(bounceDir * 400f, ForceMode.Force);
            
        }else if (direction == "forward") {
            
            Quaternion rotate = Quaternion.Euler(0f, 60f, 0f);
            Vector3 bounceDir = rotate * Vector3.forward;
            rb.AddForce(bounceDir * 400f, ForceMode.Force);
            
        }
    }

   private void OnCollisionEnter(Collision other) {
        BoxCollider bc = other.collider.GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;
        float bOfX = other.transform.position.x;
        float normalizedDistance = (bOfX - minX) / (maxX - minX);
        Quaternion rotate = Quaternion.Euler(0f, 0f, 0f);
        
        if (other.gameObject.CompareTag("LeftPaddle")) {
            Vector3 bounceDir = rotate * Vector3.back;
            Rigidbody rb = other.rigidbody;
            rb.AddForce(bounceDir*(700f+speedMultiplier),ForceMode.Force);
            if (speedMultiplier <= 2750) {
                speedMultiplier = speedMultiplier + 100;
            }
        }
        else if (other.gameObject.CompareTag("RightPaddle")) {
            Vector3 bounceDir = rotate * Vector3.forward;
            Rigidbody rb = other.rigidbody;
            rb.AddForce(bounceDir*(700f+speedMultiplier),ForceMode.Force);
            
            if (speedMultiplier <= 2750) {
                speedMultiplier = speedMultiplier + 100;
            } 
        }
    }

    public void BallReset()
    {
        rb.position = ballPos;
        rb.velocity = Vector3.zero;
        speedMultiplier = 0;

    }


}