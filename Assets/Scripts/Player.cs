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
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        // To allow movement input only if the player is not currently hopping
        if (!isHopping)
        {
            CheckMovementInput();
        }
    }

    private void CheckMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TryMoveCharacter(Vector3.right); // Move to the right (positive X direction)
            terrainGenerator.SpawnTerrain(false, transform.position);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            TryMoveCharacter(Vector3.forward); // Move forward (positive Z direction)
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            TryMoveCharacter(Vector3.back); // Move backward (negative Z direction)
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // TODO: Implement moving backwards
        }
    }


    void TryMoveCharacter(Vector3 direction)
    {
        // Cast a ray in the specified direction and check if moving would hit it
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            // For simplicity we cannot move as long as there is an object with a collider in the movement direction
            Debug.Log("Cannot move - static object in the way!");
        }
        else
        {
            // If the ray does not hit anything, move the character
            MoveCharacter(direction);
        }
    }

    private void MoveCharacter(Vector3 direction)
    {
        animator.SetTrigger("hop");
        isHopping = true;

        Vector3 positionAfterMovement = transform.position + direction;
        Transform possibleLog = GetLogNearFuturePosition(positionAfterMovement);

        if (possibleLog != null)
        {
            transform.parent = possibleLog;
            transform.localPosition = GetPlayerPositionOnLog(possibleLog, direction);
            if (transform.localPosition.z > 0.5 || transform.localPosition.z < -0.5)
            {
                transform.parent = null;
            }
        } else {
            transform.parent = null;
            transform.position += direction;
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        }
    }

    private Transform GetLogNearFuturePosition(Vector3 futurePosition)
    {
        RaycastHit hit;
        // It is important to also check for logs that are close to the future position because the logs are moving and potentially take the spot of the movement (thats why positions left and right of the future position are checked)
        Vector3[] positionsFromWhereToCheck = { futurePosition, futurePosition + new Vector3(0,0,-1), futurePosition + new Vector3(0,0,1) };

        foreach (Vector3 position in positionsFromWhereToCheck)
        {
            if (Physics.Raycast(position, Vector3.down, out hit, 1) && hit.collider.CompareTag("Log"))
            {
                // Check if the ray hit a log
                if (hit.collider.CompareTag("Log"))
                {
                    return hit.collider.transform;
                }
            }
        }

        return null;
    }

    // Function to set the value to the nearest target
    private Vector3 GetPlayerPositionOnLog(Transform log, Vector3 direction)
    {
        // Check if log is rotated and change direction of movement as it is relative of logs direction
        if (log.rotation.y < 1)
        {
            direction *= -1; 
        }

        Vector3 playerPositionOnLog = new Vector3(0, transform.localPosition.y, transform.localPosition.z - direction.z/3);

        // Calculate the absolute differences
        float diffToNeg08 = Mathf.Abs(playerPositionOnLog.z - (-0.8f));
        float diffToNeg033 = Mathf.Abs(playerPositionOnLog.z - (-0.33f));
        float diffToZero = Mathf.Abs(playerPositionOnLog.z - 0f);
        float diffToPos033 = Mathf.Abs(playerPositionOnLog.z - 0.33f);
        float diffToPos08 = Mathf.Abs(playerPositionOnLog.z - 0.8f);

        // Find the minimum difference
        float minDiff = Mathf.Min(diffToNeg08, diffToNeg033, diffToZero, diffToPos033, diffToPos08);
        
        // Set the value to the nearest target
        if (minDiff == diffToNeg08)
            playerPositionOnLog.z = -1;
        else if (minDiff == diffToNeg033)
            playerPositionOnLog.z = -0.33f;
        else if (minDiff == diffToZero)
            playerPositionOnLog.z = 0f;
        else if (minDiff == diffToPos033)
            playerPositionOnLog.z = 0.33f;    
        else if (minDiff == diffToPos08)
            playerPositionOnLog.z = 1;    
        
        return playerPositionOnLog;
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}
