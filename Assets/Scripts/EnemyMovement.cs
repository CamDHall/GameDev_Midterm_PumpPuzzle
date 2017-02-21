using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0));
        if(transform.position.x >= 5)
        {
            Destroy(this.gameObject);
        }
	}
}
