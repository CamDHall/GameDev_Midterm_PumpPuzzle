using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    float Timer;
    float spawnDecrease = 0;

	void Start () {
        Timer = Time.time + 5f;
	}
	
	void Update () {
		if(Timer < Time.time)
        {
            var enemy = Instantiate(enemyPrefab);
            int choice = Random.Range(0, 2);
            if (choice == 1)
            {
                enemy.transform.position = new Vector3(0.5f, enemy.transform.position.y, enemy.transform.position.z);
            }

            Timer = Time.time + Random.Range(6f - (spawnDecrease/2), 18f - spawnDecrease);
            if (spawnDecrease <= 12)
            {
                spawnDecrease += 0.15f;
            }
        }
	}
}
