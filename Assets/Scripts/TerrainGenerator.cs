using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;


    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();

    private void Start() 
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true);
        }
        maxTerrainCount = currentTerrains.Count;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain(false);
        }
    }

    // The method adds a lane of grass, roads or water randomly at the end of the field and removes the first lane. It basically makes the map move by one lane
    private void SpawnTerrain(bool isStart)
    {
        int whichTerrain = Random.Range(0, terrainDatas.Count);
        int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
        for (int i = 0; i < terrainInSuccession; i++)
        {
            GameObject terrain = Instantiate(terrainDatas[Random.Range(0, terrainDatas.Count)].terrain, currentPosition, Quaternion.identity, terrainHolder);
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
        
        /*
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity);
        */
    }

}
