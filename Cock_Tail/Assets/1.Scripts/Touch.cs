using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public float rayDirection;

	void Update () {
		if (Input.touchCount > 0 || Input.GetTouch (0).phase == TouchPhase.Began){
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			Debug.DrawRay (ray.origin, ray.direction * rayDirection, Color.white);

			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {	
				Debug.Log (hit.transform.gameObject.name);
			}
		}
	}
}
