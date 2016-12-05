using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {

	public float vectorSpeed;

	void Update () {
		float x = Input.acceleration.x;
		float z = Input.acceleration.z;
		// transform.Translate (0, 0, -z * vectorSpeed * Time.deltaTime);
		transform.Rotate (0, 0, -x * vectorSpeed * Time.deltaTime);
	}
}
