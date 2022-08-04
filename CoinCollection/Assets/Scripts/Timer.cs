/**** 
* Created by: Stu Dent
* Date Created: Feb 3, 2022
* 
* Last Edited by: Yaoyuan Zhang
* Last Edited: 6/20/22
* 
* Description: A level timer that can be set and controlled
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 


public class Timer : MonoBehaviour
{
    public GameManager gm;
    
    static private Timer timer; //Timer instance
    static public Timer LevelTimer { get { return timer; } } //public access to read only timer
    void CheckTimerIsInScene()
    {
    if (timer == null)
        {
            timer = this; 
            Debug.Log(timer);
        }
    else 
        {
            Destroy(this.gameObject); 
        }
    }

[Tooltip("Start time in seconds")]
public float startTime = 10f; //time for level (if level is timed)

 private float currentTime; //current time of timer

 [HideInInspector] 
public bool timerStopped = false; //check if timer is stopped


    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

private void RunTimer()
 {
    if (timerStopped)
    { // check to see if timer has stoped
        LevelEnd();
    }
    else
    { 
        if(currentTime > 0)
        { 
            // if still time, update timer countdown
            currentTime -= Time.deltaTime;
        } 
        else
        {//if the timer is less than zero
            currentTime = 0; //set time to zero
            timerStopped = true; //stop the timer
        }
        gm.timer = DisplayTime(currentTime);
    }
}
private void LevelEnd()
 {
        gm.SetTargetState(GameState.gameLevelEnded);
 Debug.Log("level end");
 }

private string DisplayTime(float timeToDispaly) 
 { 
 timeToDispaly += 1; //adds 1 to time, to accuratly refelect time in field
 float minutes = Mathf.FloorToInt(timeToDispaly / 60); //calculate timer mintues
 float seconds = Mathf.FloorToInt(timeToDispaly % 60); //calculate timer seconds
 return string.Format("{0:00}:{1:00}", minutes, seconds); //retrun time as string
 }
    void Awake()
    { 
 //runs the method to check for the Timer
        CheckTimerIsInScene();
        
    }
}
