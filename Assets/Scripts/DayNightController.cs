using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightController : MonoBehaviour
{
    public float dayLength = 10.0f;
    public float nightLength = 10.0f;
    public float transitionLength = 5;

    public Color dayColor = new Color(1.0f,1.0f,1.0f);
    public Color nightColor = new Color(.25f,.25f,.6f);

    private Light2D light2d;

    public bool daytime { get; private set;}
    private float timeRemaining;
    private float colorTimer;

    private bool transitioning = false;

    void Start()
    {
        light2d = FindObjectOfType<Light2D>();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            daytime = !daytime;
            colorTimer = transitionLength;
            transitioning = true;

            if(daytime)
            {
                timeRemaining = dayLength;
            }
            else
            {
                timeRemaining = nightLength;
            }
        }
        if(daytime)
        {
            light2d.color = Color.Lerp(nightColor, dayColor, colorTimer);
                
        }
        else
        {
            light2d.color = Color.Lerp(dayColor, nightColor, colorTimer);
                
        }

        if(transitioning)
        {
            colorTimer -= Time.deltaTime;
        }

        if(colorTimer <= 0)
        {
            transitioning = false;
        }
    }
}
