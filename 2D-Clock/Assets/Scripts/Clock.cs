using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Clock : MonoBehaviour
{
    //Initialize variables

    GameObject anaSeconds;
    GameObject anaMinutes;
    GameObject anaHours;

    public Text digiSecondText;
    public Text digiMinuteText;
    public Text digiHourText;

   

    float secAndMinAngle = 360f / 60f;
    float hoursAngle = 360f / 12f;

    DateTime currentTime;
    float currentSeconds;
    float currentMinutes;
    float currentHours;


    // Start is called before the first frame update
    void Start()
    {
        //References to Game objects
        anaSeconds = GameObject.Find("AnaSeconds");
        anaMinutes = GameObject.Find("AnaMinutes");
        anaHours = GameObject.Find("AnaHours");

        ////Get the current system time
        //currentTime = DateTime.Now;
        ////Copy the time into variables
        //currentSeconds = currentTime.Second;
        //currentMinutes = currentTime.Minute;
        //currentHours = currentTime.Hour;
        
        //initializeAnaClock();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current system time
        currentTime = DateTime.Now;
        //Copy the time into variables
        currentSeconds = currentTime.Second;
        currentMinutes = currentTime.Minute;
        currentHours = currentTime.Hour;
        //Set the canvas text object's text to current time
        digiSecondText.text = currentSeconds.ToString();
        digiMinuteText.text = currentMinutes.ToString();
        digiHourText.text = currentHours.ToString();
    }
    private void FixedUpdate()
    {
        //manage the analog clock
        rotateAnalogClock();
    }

    void rotateAnalogClock()
    {
        anaSeconds.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        anaMinutes.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        anaHours.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //set the seconds and minute pointer
        anaSeconds.transform.Rotate(0.0f, 0.0f, currentSeconds * secAndMinAngle * -1.0f);
        anaMinutes.transform.Rotate(0.0f, 0.0f, currentMinutes * secAndMinAngle * -1.0f);
        //calculate distance between the hours
        float hourDistance = currentMinutes / 60f;
        anaHours.transform.Rotate(0.0f, 0.0f, (currentHours + hourDistance) * hoursAngle * -1.0f);
    }
}

