using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooBoo : MonoBehaviour {
	public GameObject booParticle;
	public GameObject boomParticle;
	public int objectHealth;

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.CompareTag("object") == true) 
		{

			GameObject obj = Instantiate (booParticle);
			obj.transform.position = transform.position;

			objectHealth -= 1;

			if (objectHealth <= 0) {
				
				GameObject boom = Instantiate (boomParticle);
				boom.transform.position = transform.position;

				Destroy (gameObject);
				Destroy (boomParticle, 2);
			}

			Destroy (booParticle, 2);
		}
	}
}
