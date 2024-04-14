using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;

    private Animator animator;
    private bool isHopping;
    private int score;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        score++;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        // Check for movement input only if the player is not currently hopping
        if (!isHopping)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMoveCharacter(Vector3.right); // Move to the right (positive X direction)
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                TryMoveCharacter(Vector3.forward); // Move forward (positive Z direction)
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                TryMoveCharacter(Vector3.back); // Move backward (negative Z direction)
            }
        }
    }

    void TryMoveCharacter(Vector3 direction)
    {
        // Cast a ray in the specified direction
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1f)) // Adjust the distance as needed
        {
            // Check if the object hit by the ray is tagged as a static object
            if (hit.transform.CompareTag("StaticObject"))
            {
                Debug.Log("Cannot move - static object in the way!");
                // You can add additional logic here, such as playing a sound or displaying a message to the player
            }
            else
            {
                // If no static object is in the way, move the character
                MoveCharacter(direction);
            }
        }
        else
        {
            // If the ray does not hit anything, move the character
            MoveCharacter(direction);
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "StaticObject") {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }
        if (collision.transform.GetComponent<MovingObject>() != null)
        {
            transform.parent = collision.collider.transform;
        }    
        else
        {
            transform.parent = null;
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position += difference;
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        Debug.Log(transform.position);
        terrainGenerator.SpawnTerrain(false, transform.position);
    }

    public void FinishHop()
    {
        isHopping = false;
        Debug.Log("Finished hop: " + transform.position);

    }
}
