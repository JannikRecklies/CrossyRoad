using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject vehicle;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSperarationTime;
    [SerializeField] private float maxSperarationTime;
    [SerializeField] private bool isRightSide;

    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    // Update is called once per frame
    private IEnumerator SpawnVehicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSperarationTime, maxSperarationTime));
            GameObject go = Instantiate(vehicle, spawnPos.position, Quaternion.identity);
            if (!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
