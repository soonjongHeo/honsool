using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour {

	public int selfyRotateSpeed;
	
	void Update () {
		gameObject.transform.Rotate (0, selfyRotateSpeed * Time.deltaTime, 0);
	}
}
