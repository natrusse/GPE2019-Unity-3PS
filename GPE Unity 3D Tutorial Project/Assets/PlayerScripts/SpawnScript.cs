using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public float totalEnemies;
    public float remainingLives;
    public float spawnLimit;
    public float killStreak;
    Playerhealth playerHealth;
    EnemyHealth enemyHealth;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public float player = 1;

    public Transform enemyTarget;

    public List<Transform> enemySpawnLocations;
    public List<Transform> playerSpawnLocations;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (totalEnemies < spawnLimit)
        {
            int index = UnityEngine.Random.Range(0, enemySpawnLocations.Count);

            GameObject Enemy = Instantiate(enemyPrefab, enemySpawnLocations[index].position, enemySpawnLocations[index].rotation);
            ++totalEnemies;

            EnemyMovement mover = Enemy.GetComponent<EnemyMovement>();
            if (mover)
            {
                mover.target = enemyTarget;
                mover.spawner = this;
            }
            // instantiate enemies at location 1 2 3
        }
	}

    private void respawnPlayer()
    {
        if (player != 1)
        {
            int index = UnityEngine.Random.Range(0, playerSpawnLocations.Count);
            GameObject Player = Instantiate(playerPrefab, playerSpawnLocations[index].position, playerSpawnLocations[index].rotation);
            --remainingLives;
            ++player;
        }
    }
}
