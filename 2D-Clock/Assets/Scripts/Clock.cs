/*
 * Author: Samuli Lehtonen
 * Version: 1.0
 * Creation date: 29.03.2020
 * Short script description: This script gets system's current clock time and shows it as a digital type and analog type clock.
 * 
 ** How to use the script:
 *** 1. First you need to create Clock frames for the analog and digital clock.
 *** 2. Then you need to have 3 gameobjects that represents seconds, minutes and hour pointers named as: AnaSeconds, AnaMinutes and AnaHours
 *** 3. Then you need to have 3 text objects and attach them correctly for the script in Unity inspector: Digi Second Text, Digi Minute Text and Digi Hour Text;
 *** 
 * 
 * ** Revision history: 29.03.2020 ~~ Version 1.0 created
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Clock : MonoBehaviour
{
    //Declaring Gameobjects
    GameObject anaSeconds;
    GameObject anaMinutes;
    GameObject anaHours;
    //Declaring Canvas text
    public Text digiSecondText;
    public Text digiMinuteText;
    public Text digiHourText;
    //Declaring time variables
    DateTime currentTime;
    float currentSeconds;
    float currentMinutes;
    float currentHours;

    //Initializing Angle variables
    float secAndMinAngle = 360f / 60f;
    float hoursAngle = 360f / 12f;

    // Start is called before the first frame update
    void Start()
    {
        //References to Game objects
        anaSeconds = GameObject.Find("AnaSeconds");
        anaMinutes = GameObject.Find("AnaMinutes");
        anaHours = GameObject.Find("AnaHours");
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current system time
        currentTime = DateTime.Now;
        //Cut the time into seconds,minutes and hours
        currentSeconds = currentTime.Second;
        currentMinutes = currentTime.Minute;
        currentHours = currentTime.Hour;
        //Set the canvas text object's text to current time
        digiSecondText.text = currentSeconds.ToString();
        digiMinuteText.text = currentMinutes.ToString();
        digiHourText.text = currentHours.ToString();
    }
    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        //manage the analog clock
        rotateAnalogClock();
    }

    void rotateAnalogClock()
    {
        //Initialize angles
        anaSeconds.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        anaMinutes.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        anaHours.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //rotate the seconds and minute pointer according the current seconds multiplied by the angle
        anaSeconds.transform.Rotate(0.0f, 0.0f, currentSeconds * secAndMinAngle * -1.0f);
        anaMinutes.transform.Rotate(0.0f, 0.0f, currentMinutes * secAndMinAngle * -1.0f);
        //calculate distance between the hours to get correct rotation
        float hourDistance = currentMinutes / 60f;
        //rotate the hour pointer according the current hour+the distance multiplied by the angle
        anaHours.transform.Rotate(0.0f, 0.0f, (currentHours + hourDistance) * hoursAngle * -1.0f);
    }
}

