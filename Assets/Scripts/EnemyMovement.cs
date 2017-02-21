using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	
	void Update () {
        if(transform.position.x == 0.5f)
        {
            // transform.Rotate
        }
        GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0));
        if(transform.position.x >= 5)
        {
            Destroy(this.gameObject);
        }
	}
}
