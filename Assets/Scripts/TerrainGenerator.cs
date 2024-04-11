using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;


    [HideInInspector] private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();

    private void Start() 
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;
    }

    // The method adds a lane of grass, roads or water randomly at the end of the field and removes the first lane. It basically makes the map move by one lane
    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if ((currentPosition.x - playerPos.x < minDistanceFromPlayer) || isStart)
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrains[Random.Range(0, terrainDatas[whichTerrain].possibleTerrains.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]); // Removes the object from the view (not visible afterwards anymore)
                        currentTerrains.RemoveAt(0); // Removes the object from the list
                    }
                }
                currentPosition.x++;
            }
        }
    }

}
