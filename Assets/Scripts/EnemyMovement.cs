using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float initialX = 0;
    float increaseingSpeed = 0;

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
            GetComponent<Rigidbody>().AddForce(new Vector3(-(0.3f + Spawner.accelerator), 0, 0));
        } else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3((0.3f + Spawner.accelerator), 0, 0));
        }

        if(transform.position.x >= 5 || transform.position.x <= -5f)
        {
            Destroy(this.gameObject);
        }
	}
}
