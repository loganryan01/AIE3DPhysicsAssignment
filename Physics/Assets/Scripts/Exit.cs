using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class Exit : MonoBehaviour
{
    public Timer timer;
    private static float finalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rifle rifleScript = other.gameObject.GetComponentInChildren<Rifle>();

            if (rifleScript.botsKilled == 19)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                finalTime = timer.currentTime;

                WriteString();

                SceneManager.LoadScene(2);

                //Debug.Log(finalTime);
                
                //FinalTime finalTimeScript = text.GetComponent<FinalTime>();
                //Debug.Log(finalTimeScript);
                //finalTimeScript.finalTime = finalTime;

                //FinalTime finalTimeScript = SceneManager.GetSceneAt(2).GetRootGameObjects()[3].GetComponent<FinalTime>();
                //FinalTime finalTimeScript = GameObject.Find("Canvas").GetComponent<FinalTime>();
                //finalTimeScript.finalTime = timer.currentTime;

            }
        }
    }

    [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/Resources/text.txt";

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(finalTime);
        writer.Close();
    }
}
