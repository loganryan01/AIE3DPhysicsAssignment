using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// The starting time
    /// </summary>
    public float startingTime = 0;

    /// <summary>
    /// The current time
    /// </summary>
    [HideInInspector]
    public float currentTime;

    /// <summary>
    /// Text that diplays the time
    /// </summary>
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        DisplayTime(currentTime);
    }

    /// <summary>
    /// Display the current time
    /// </summary>
    /// <param name="timeToDisplay">The time to display on the screen</param>
    void DisplayTime(float timeToDisplay)
    {
        // Increase time by 1
        timeToDisplay += 1;

        // Convert to minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Write text
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
