using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMovement : MonoBehaviour {

    Vector3 initialPos;

	void Start () {
        initialPos = transform.localPosition;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localPosition = new Vector3(initialPos.x, initialPos.y - 0.2f, initialPos.z - 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localPosition = initialPos;
        }
    }
}
