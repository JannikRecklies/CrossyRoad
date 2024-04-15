using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
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
                transform.parent = null;
                TryMoveCharacter(Vector3.right); // Move to the right (positive X direction)
                terrainGenerator.SpawnTerrain(false, transform.position);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.parent = null;
                TryMoveCharacter(Vector3.forward); // Move forward (positive Z direction)
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.parent = null;
                TryMoveCharacter(Vector3.back); // Move backward (negative Z direction)
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                
            }
            
        }
    }

    void TryMoveCharacter(Vector3 direction)
    {
        // Cast a ray in the specified direction
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1f) || Physics.Raycast(transform.position, direction, out hit, 1f) ) // Adjust the distance as needed
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
 
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;

        if (IsLogNearFuturePosition(difference))
        {
            transform.position += difference;
            float newZ = GetNewPositionOnLog(transform.localPosition.z);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZ);
            if (newZ > 0.5 || newZ < -0.5)
            {
                transform.parent = null;
            }
            
        } else {
            transform.position += difference;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        }
    }

    public void FinishHop()
    {
        isHopping = false;
    }

    private bool IsLogNearFuturePosition(Vector3 direction)
    {
        // Cast a ray in the player's forward direction to check for logs
        RaycastHit hit;
        if (Physics.Raycast(transform.position + direction, new Vector3(0, -1, 0), out hit, 2))
        {
            // Check if the ray hit a log
            if (hit.collider.CompareTag("Log"))
            {
                transform.parent = hit.collider.transform;
                return true;
            }
        }
        if (Physics.Raycast(transform.position + direction + new Vector3(0,0,-1), new Vector3(0, -1, 0), out hit, 2))
        {
            // Check if the ray hit a log
            if (hit.collider.CompareTag("Log"))
            {
                transform.parent = hit.collider.transform;
                return true;
            }
        }
        if (Physics.Raycast(transform.position + direction + new Vector3(0,0,1), new Vector3(0, -1, 0), out hit, 2))
        {
            // Check if the ray hit a log
            if (hit.collider.CompareTag("Log"))
            {
                transform.parent = hit.collider.transform;
                return true;
            }
        }

        return false;
    }

    // Function to set the value to the nearest target
    float GetNewPositionOnLog(float value)
    {
        // Calculate the absolute differences
        float diffToNeg08 = Mathf.Abs(value - (-0.8f));
        float diffToNeg033 = Mathf.Abs(value - (-0.33f));
        float diffToZero = Mathf.Abs(value - 0f);
        float diffToPos033 = Mathf.Abs(value - 0.33f);
        float diffToPos08 = Mathf.Abs(value - 0.8f);

        // Find the minimum difference
        float minDiff = Mathf.Min(diffToNeg08, diffToNeg033, diffToZero, diffToPos033, diffToPos08);
        
        // Set the value to the nearest target
        if (minDiff == diffToNeg08)
            return -1;
        else if (minDiff == diffToNeg033)
            return -0.33f;
        else if (minDiff == diffToZero)
            return 0f;
        else if (minDiff == diffToPos033)
            return 0.33f;    
        else if (minDiff == diffToPos08)
            return 1;    
        else 
            return value;
    }
}
