using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject movingObject;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSperarationTime;
    [SerializeField] private float maxSperarationTime;
    [SerializeField] private bool isRightSide;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSperarationTime, maxSperarationTime));
            GameObject go = Instantiate(movingObject, spawnPos.position, Quaternion.identity);
            if (!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
