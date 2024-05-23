using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if(player != null)
        {
            player.Kill();
            MakeSound();
        }
    }

    // Happens when player on log
    private void OnTriggerEnter(Collider other) {
        Player player = other.GetComponent<Player>();
        if(player != null && transform.CompareTag("EdgeOfMap"))
        {
            FollowPlayer cam = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
            cam.StopFollowingPlayer();
        }
    }

    private void MakeSound() {
        if (gameObject.CompareTag("Water"))
        {
            FindAnyObjectByType<AudioManager>().Play("WaterSplash");
        }
        if (gameObject.CompareTag("Car"))
        {
            FindAnyObjectByType<AudioManager>().Play("CarBump");
        }
    }
}
