using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwipeDetection : MonoBehaviour
{    
    private Vector2 startTouchPos, endTouchPos;

    float startTime, endTime;
    [Header("Max time to detect swipe"), Range(0.1f, 2.0f)]
    public float maximumTime = 1.0f;
    [Header("How close swipe is to up,down,right,left"), Range(0.1f, 0.95f)]
    public float directionTreshold = 0.65f;

    [Header("References")]
    public Player_Movement_Blocky playerMovement;

    private void Update() 
    {
        //PC CONTROLS
        if(Input.GetMouseButtonDown(0)) //StartPos
        {
            startTouchPos = Input.mousePosition;

            startTime = Time.time;
        }

        if(Input.GetMouseButtonUp(0)) //EndPos
        {
            endTouchPos = Input.mousePosition;

            endTime = Time.time;

            DetectSwipe();
        }

        //TOUCH CONTROLS
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) //startPos
            {
                startTouchPos = Input.GetTouch(0).position;

                startTime = Time.time;
            }
            
            if(Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended) //endPos
            {
                endTouchPos = Input.GetTouch(0).position;

                endTime = Time.time;

                DetectSwipe();
            }
            
        }
    }

    private void DetectSwipe()
    {
        if(endTime - startTime < maximumTime)
        {
            Debug.DrawLine(startTouchPos, endTouchPos, Color.red, 3f);
            Vector2 direction = (endTouchPos - startTouchPos).normalized;

            SwipeDirection(direction);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        /*
        txtThree.text = "";
        txtThree.text = "UP: "+ Vector2.Dot(Vector2.up, direction);
        txtThree.text += "\n D:"+Vector2.Dot(Vector2.down, direction);
        txtThree.text += "\n R:"+ Vector2.Dot(Vector2.right, direction);
        txtThree.text += "\n L:"+ Vector2.Dot(Vector2.left, direction) ;
        */

        if( Vector2.Dot(Vector2.up, direction) > directionTreshold)
        {
            playerMovement.MoveUp();
        }
        else if(Vector2.Dot(Vector2.down, direction) > directionTreshold)
        {
            playerMovement.MoveDown();
        }
        else if(Vector2.Dot(Vector2.right, direction) > directionTreshold)
        {
            playerMovement.MoveRight();
        }
        else if(Vector2.Dot(Vector2.left, direction) > directionTreshold)
        {
            playerMovement.MoveLeft();
        }
        else 
        {
            //move nothing
        }
    }
}
