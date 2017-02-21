using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    Vector3 initialPos;

	void Start () {
        initialPos = transform.localPosition;
	}
	
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.localPosition = new Vector3(initialPos.x, initialPos.y - 0.2f, initialPos.z - 0.4f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localPosition = initialPos;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Death");
            Debug.Log("DEATH");
        }
    }
}
