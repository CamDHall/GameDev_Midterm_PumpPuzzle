using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    float Timer;

	void Start () {
        Timer = Time.time + 5f;
	}
	
	void Update () {
		if(Timer < Time.time)
        {
            Instantiate(enemyPrefab);
            Timer = Time.time + 5f;
        }
	}
}
