using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.playerOnPlatform = false;
        }
    }
}
