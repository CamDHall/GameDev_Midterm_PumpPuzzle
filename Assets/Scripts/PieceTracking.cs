using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTracking : MonoBehaviour {



	void Start () {
		
	}
	
	void Update () {
		if(Vector3.Distance(EnemyMovement.enemyPos, transform.position) <= 5f)
        {
            Debug.Log("Worked");
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, EnemyMovement.enemyPos.x, 1.5f * Time.deltaTime),  Mathf.Lerp(transform.position.y, EnemyMovement.enemyPos.y, 1.5f * Time.deltaTime), Mathf.Lerp(transform.position.z, EnemyMovement.enemyPos.z, 1.5f * Time.deltaTime));
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject, 6f);
        Destroy(this.gameObject);
        coll.gameObject.GetComponent<Rigidbody>().AddForce(-150, 1, 1);
    }
}
