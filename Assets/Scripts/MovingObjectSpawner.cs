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
        int randomInitialSpawnPos = Mathf.RoundToInt(Random.Range(spawnPos.position.z - 20, spawnPos.position.z));
        temp.z = randomInitialSpawnPos;
        SpawnObject(temp);
        StartCoroutine(SpawnObjectRoutine());
    }

    private IEnumerator SpawnObjectRoutine() {
        while (true)
        {
            int waitTime = Random.Range(minSperarationTime, maxSperarationTime);
            yield return new WaitForSeconds(Mathf.RoundToInt(waitTime));
            SpawnObject(spawnPos.position);
        }
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
