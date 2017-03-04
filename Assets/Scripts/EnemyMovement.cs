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
        if (initialX == 193)
        {
            transform.Rotate(0, 180, 0);
        }
    }

	void Update () {
        enemyPos = transform.position;

        if(initialX == 193)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-(3f + Spawner.accelerator), 0, 0));
        } else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3((3f + Spawner.accelerator), 0, 0));
        }

        if(transform.position.x >= 200 || transform.position.x <= -200f)
        {
            Destroy(this.gameObject);
        }
	}
}
