using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceTracking : MonoBehaviour {

    bool clicked = false;
	
	void Update () {
        if(clicked)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, EnemyMovement.enemyPos.x, 1.25f * Time.deltaTime), Mathf.Lerp(transform.position.y, EnemyMovement.enemyPos.y, 1.25f * Time.deltaTime), Mathf.Lerp(transform.position.z, EnemyMovement.enemyPos.z, 1.5f * Time.deltaTime));
        }
	}

    void OnMouseUp()
    {
        clicked = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject, 0.5f);
        clicked = false;
        Destroy(this.gameObject);
    }
}
