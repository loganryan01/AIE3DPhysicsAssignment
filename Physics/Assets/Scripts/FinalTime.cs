using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FinalTime : MonoBehaviour
{
    /// <summary>
    /// The text that displays the time
    /// </summary>
    public Text timeText;

    /// <summary>
    /// The players time when they touched the exit
    /// </summary>
    private static float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        ReadString();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(finalTime);
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

    /// <summary>
    /// Read the text file
    /// </summary>
    static void ReadString()
    {
        // Location of text file
        string path = "Assets/Resources/text.txt";

        // Info from the text file
        string info;

        // Read the text file
        StreamReader reader = new StreamReader(path);
        info = reader.ReadToEnd();

        // Convert to float
        finalTime = System.Single.Parse(info);

        // Close file
        reader.Close();
    }
}
