using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject movingObject;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private int minSperarationTime;
    [SerializeField] private int maxSperarationTime;
    [SerializeField] private bool isRightSide;

    void Start()
    {
        Vector3 temp = spawnPos.position;
        int randomInitialSpawnPos = Mathf.RoundToInt(Random.Range(spawnPos.position.z - 10, spawnPos.position.z));
        temp.z = randomInitialSpawnPos;
        SpawnObject(temp);
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            float waitTime = CalculateWaitTime();
            yield return new WaitForSeconds(waitTime);
            SpawnObject(spawnPos.position);
        }
    }

    private float CalculateWaitTime()
    {
        float waitTime = Random.Range(minSperarationTime, maxSperarationTime);
        
        if (movingObject.name == "Log")
        {
            MovingObject movingObjectScript = movingObject.GetComponent<MovingObject>();
            int speed = movingObjectScript.GetSpeed();
            float additionalWaitTime = Random.Range(0, speed+1) / (float)speed;
            waitTime += additionalWaitTime;
        }

        return waitTime;
    }

    // Update is called once per frame
    private void SpawnObject(Vector3 spawnPosition)
    {
        GameObject go = Instantiate(movingObject, spawnPosition, Quaternion.identity);
        if (!isRightSide)
        {
            go.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
