using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// The timer scipt
    /// </summary>
    public Timer timer;

    /// <summary>
    /// The players time when they touched the exit
    /// </summary>
    private static float finalTime;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger
    /// </summary>
    /// <param name="other">Collider of the colliding game object</param>
    private void OnTriggerEnter(Collider other)
    {
        // If the player has touched the exit
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the rifle script
            Rifle rifleScript = other.gameObject.GetComponentInChildren<Rifle>();

            // Check that the player has killed all the ragdolls
            if (rifleScript.botsKilled == 19)
            {
                // Save the time and go to the next scene
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                finalTime = timer.currentTime;

                WriteString();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    /// <summary>
    /// Write the players time onto a text file
    /// </summary>
    static void WriteString()
    {
        // Location of the text file
        string path = "Assets/Resources/text.txt";

        // Write the players final time
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(finalTime);

        // Close the file
        writer.Close();
    }
}
