using System.Collections;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject movingObjectPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int minSeparationTime;
    [SerializeField] private int maxSeparationTime;
    [SerializeField] private bool isRightSide;

    private float randomSpeedAddition;

    private void Start()
    {
        randomSpeedAddition = Random.Range(-1f, 1f);
        //InitializeSpawner();
        StartCoroutine(SpawnObjectRoutine());
    }

    // TODO: Make objects already be present when starting the game
    private void InitializeSpawner()
    {
        Vector3 initialSpawnPosition = spawnPosition.position;
        initialSpawnPosition.z = Mathf.RoundToInt(Random.Range(spawnPosition.position.z - 10, spawnPosition.position.z));
        SpawnObject(initialSpawnPosition);
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            SpawnObject(spawnPosition.position);
            
            float waitTime = Random.Range(minSeparationTime, maxSeparationTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnObject(Vector3 spawnPosition)
    {
        GameObject spawnedObject = Instantiate(movingObjectPrefab, spawnPosition, Quaternion.identity);
        
        if (!isRightSide)
        {
            spawnedObject.transform.Rotate(0, 180, 0);
        }

        AdjustObjectSpeed(spawnedObject);
    }

    private void AdjustObjectSpeed(GameObject spawnedObject)
    {
        MovingObject movingObjectScript = spawnedObject.GetComponent<MovingObject>();
        movingObjectScript.SetAddtionalSpeed(randomSpeedAddition);
    }
}
