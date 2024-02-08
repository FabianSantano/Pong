using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    private GoalTrigger goal;
    public int right=0;
    public int left=0;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leftGameScore()
    {
        
            Debug.Log($"Left Paddle Scored! Score Right: {right} Left: {left}");
            
        
        
    }
    public void rightGameScore()
    {
        
        Debug.Log($"Right Paddle Scored! Score Right: {right} Left: {left}");
            
        
        
    }

    public void scoreRest()
    {
        right = 0;
        left = 0;
    }
    
    
}
