using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private List<GameObject> spawnTerrains = new List<GameObject>();
    [SerializeField] private Transform terrainHolder;


    [HideInInspector] private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();

    private void Start()
    {
        SpawnGrassForStart();
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;
    }

    private void SpawnGrassForStart()
    {
        for (int i = -10; i < 4; i++) 
        {
            if (i <= -4)
            {
                Vector3 temp = new Vector3(i, 0, 0);
                GameObject grassTerrain = Instantiate(spawnTerrains[Random.Range(0, spawnTerrains.Count)], temp, Quaternion.identity, terrainHolder); // Assuming grass terrain is the first terrain in your list
                currentTerrains.Add(grassTerrain);    
            }
            else
            {
                GameObject grassTerrain = Instantiate(terrainDatas[0].possibleTerrains[0], currentPosition, Quaternion.identity, terrainHolder); // Assuming grass terrain is the first terrain in your list
                currentTerrains.Add(grassTerrain);
                currentPosition.x = i;
            }
        }
    }


    // The method adds a lane of grass, roads, or water randomly at the end of the field and removes the first lane. It basically makes the map move by one lane.
    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if (ShouldSpawnTerrain(isStart, playerPos))
        {
            int whichTerrain = DetermineNextTerrainType();
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);

            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = InstantiateTerrain(whichTerrain);

                currentTerrains.Add(terrain);

                if (!isStart)
                {
                    MaintainMaxTerrainCount();
                }

                currentPosition.x++;
            }
        }
    }

    private bool ShouldSpawnTerrain(bool isStart, Vector3 playerPos)
    {
        return (currentPosition.x - playerPos.x < minDistanceFromPlayer) || isStart;
    }

    private int DetermineNextTerrainType()
    {
        GameObject lastTerrain = currentTerrains[currentTerrains.Count - 1];
        
        if (lastTerrain.name.ToLower().Contains("grass"))
        {
            // Ensure we do not choose grass again immediately after grass
            return Random.Range(1, terrainDatas.Count);
        }

        return 0; // Default to the first terrain type (e.g., grass)
    }

    private GameObject InstantiateTerrain(int whichTerrain)
    {
        GameObject terrainPrefab = terrainDatas[whichTerrain].possibleTerrains[Random.Range(0, terrainDatas[whichTerrain].possibleTerrains.Count)];
        return Instantiate(terrainPrefab, currentPosition, Quaternion.identity, terrainHolder);
    }

    private void MaintainMaxTerrainCount()
    {
        if (currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]); // Removes the object from the view (not visible afterwards anymore)
            currentTerrains.RemoveAt(0); // Removes the object from the list
        }
    }


}
