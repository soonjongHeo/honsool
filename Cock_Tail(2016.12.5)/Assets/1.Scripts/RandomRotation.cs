using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

	void Update () {
		float x = Random.Range (-180.0f, 180.0f);
		float y = Random.Range (-180.0f, 180.0f);
		float z = Random.Range (-180.0f, 180.0f);

		gameObject.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (x, y, z);
	}
}
