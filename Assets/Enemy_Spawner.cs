using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    // Variables
    public float enemySpawnTimer = 5f;
    float currSpawnTimer;
    public enum SpawnMode { waiting, spawning };
    SpawnMode spawnMode = SpawnMode.spawning;
    public int maxEnemies;
    List<Monster_AI> enemies;

    // Spawning Range
    public float spawnRangeMinX;
    public float spawnRangeMaxX;
    public float spawnRangeMinZ;
    public float spawnRangeMaxZ;
    public float spawnRangeHeight;
    public float spawnHeight;
    public float spawnCenterOffset;

    // Enemies
    public GameObject enemyPrefab;

    // Enemy spawn positions
    public GameObject[] spawnPositions;

	// Use this for initialization
	void Start () {
        currSpawnTimer = enemySpawnTimer;
        enemies = new List<Monster_AI>();
	}
	
	// Update is called once per frame
	void Update () {

        // Check if enemies are dead
        if (enemies.Count < maxEnemies)
        {
            spawnMode = SpawnMode.spawning;
        }
        else
        {
            spawnMode = SpawnMode.waiting;
        }

        // If spawning...
        if (spawnMode == SpawnMode.spawning)
        {
            // Check if the spawn timer has passed
            if (currSpawnTimer >= 0f)
            {
                currSpawnTimer -= Time.deltaTime;
            }
            // Otherwise if it has, spawn enemies and reset the timer
            else
            {
                int min = 0;
                int max = spawnPositions.Length - 1;
                int randomIndex = Random.Range(min, max);
                Debug.Log(randomIndex);
                GameObject enemy = Instantiate(enemyPrefab, spawnPositions[randomIndex].transform.position, spawnPositions[randomIndex].transform.rotation) as GameObject;
                enemies.Add(enemy.GetComponent<Monster_AI>());
                currSpawnTimer = enemySpawnTimer;
            }
        }
	}

    // Remove an enemy from the list. Called by the enemy about to self destruct
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<Monster_AI>());
    }

    public void InitializeSpawners()
    {
        // position spawn positions
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            // Get an origin within the range
            float x = Random.Range(spawnRangeMinX, spawnRangeMaxX);
            float z = Random.Range(spawnRangeMinZ, spawnRangeMaxZ);
            Vector3 origin = new Vector3(x, spawnRangeHeight, z);

            // Cast the ray
            RaycastHit hit;
            if (Physics.Raycast(origin, Vector3.down, out hit))
            {
                Vector3 position = hit.point;
                position.y += spawnHeight;

                // Make sure the position is never too close
                if (position.z <= 0f && position.z > -spawnCenterOffset)
                {
                    position.z -= spawnCenterOffset;
                }
                else if (position.z >= 0f && position.z <= spawnCenterOffset)
                {
                    position.z += spawnCenterOffset;
                }
                if (position.x <= 0f && position.x > -spawnCenterOffset)
                {
                    position.x -= spawnCenterOffset;
                }
                else if (position.x >= 0f && position.x <= spawnCenterOffset)
                {
                    position.x += spawnCenterOffset;
                }

                spawnPositions[i].transform.position = position;
            }
            else
            {
                Destroy(spawnPositions[i]);
            }
        }
    }

    public void DestroyEnemies()
    {
        foreach(Monster_AI enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
