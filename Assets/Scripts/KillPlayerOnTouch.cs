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
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Player>() != null && transform.CompareTag("EdgeOfMap"))
        {
            FollowPlayer cam = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
            cam.StopFollowingPlayer();
        }
    }
}
