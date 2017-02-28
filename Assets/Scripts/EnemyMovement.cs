using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float initialX = 0;
    float accelator = 0;

    // Pieces
    public static Vector3 enemyPos;

    void Start()
    {
        initialX = transform.position.x;
    }

	void Update () {
        enemyPos = transform.position;

        if(initialX == 0.5f)
        {
            transform.position = new Vector3(transform.position.x - (Time.deltaTime * 0.9f), transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(transform.position.x + (Time.deltaTime * 0.9f), transform.position.y, transform.position.z);
        }

        if(transform.position.x >= 5 || transform.position.x <= -5f)
        {
            Destroy(this.gameObject);
        }
	}
}
