using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger
    /// </summary>
    /// <param name="other">Collider of the colliding game object</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.playerOnPlatform = true;
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger
    /// </summary>
    /// <param name="other">Collider of the colliding game object</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.playerOnPlatform = false;
        }
    }
}
