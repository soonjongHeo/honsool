using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {

	public GameObject player; /* First Person Controller parent node */
	// public GameObject target; /* First Person Controller children node */

	void Start () {
		player.transform.position = this.transform.position;
		this.transform.parent = player.transform;

		/* Activate the gyroscope */
		Input.gyro.enabled = true;
	}

	void Update () {
		// Rotate the player and target using the gyroscope rotation rate
		/* player.transform.Rotate (0, -Input.gyro.rotationRateUnbiased.y, 0);
		this.transform.Rotate (-Input.gyro.rotationRateUnbiased.x, 0, 0); */

		var y = Input.gyro.rotationRateUnbiased.y;
		player.transform.eulerAngles = new Vector3 (0, y, 0);
	}
}
