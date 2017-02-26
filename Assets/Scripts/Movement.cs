using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    Vector3 initialPos;
    float Timer;

	void Start () {
        initialPos = transform.localPosition;
        Timer = Time.time;
	}
	
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.S))
        {
            Timer = Time.time + 3f;
            transform.localPosition = new Vector3(initialPos.x, initialPos.y - 0.2f, initialPos.z - 0.5f);
        }

        if(transform.localPosition.y == initialPos.y - 0.2f && Time.time > Timer)
        {
            transform.localPosition = initialPos;
            Timer = Time.time + 3f;
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
