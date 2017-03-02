using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    Vector3 initialPos;
    float Timer;
    float timerDecrease;

	void Start () {
        initialPos = transform.localPosition;
        Timer = Time.timeSinceLevelLoad;
	}
	
	void Update () {
        if(timerDecrease >= 0.9f)
        {
            timerDecrease = Spawner.accelerator / 3;
        } else
        {
            timerDecrease = 0.9f;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Timer = Time.timeSinceLevelLoad + (2f - timerDecrease);
            transform.localPosition = new Vector3(initialPos.x, initialPos.y - 0.4f, initialPos.z - 0.6f);
        }

        if(Time.timeSinceLevelLoad >= Timer)
        {
            transform.localPosition = initialPos;
            Timer = Time.timeSinceLevelLoad + (2f - timerDecrease);
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
        }
    }
}
