using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject dirtPrefab;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 2, 2);
        InvokeRepeating("SpawnDirt", 2.5f, 2.5f);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void SpawnObstacles()
    {
        if (gameManager.isGameActive)
        {
            // Spawn random obstacles in randomized locations.
            Vector3 spawnLocation = new Vector3(6, 0, Random.Range(-4, -1));
            int index = Random.Range(0, obstaclePrefabs.Length);

            Instantiate(obstaclePrefabs[index], spawnLocation, obstaclePrefabs[index].transform.rotation);
        }
    }

    void SpawnDirt()
    {
        if (gameManager.isGameActive)
        {
            // Spawn dirt patches in randomized locations.
            Vector3 spawnLocation = new Vector3(6, 0, Random.Range(-4, -1));
            Instantiate(dirtPrefab, spawnLocation, dirtPrefab.transform.rotation);
        }
    }
}
