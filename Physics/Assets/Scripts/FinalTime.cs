using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class FinalTime : MonoBehaviour
{
    public Text timeText;
    [HideInInspector]
    public static float finalTime;

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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/Resources/text.txt";
        string info;

        StreamReader reader = new StreamReader(path);
        info = reader.ReadToEnd();
        finalTime = System.Single.Parse(info);
        reader.Close();
    }
}
