using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

	LayerMask layerMask = 1 << 8;
	Ray ray;
	RaycastHit hit;
	public float rayDirection;

	public GameObject hitSparkPrefabs;
	ParticleSystem ps;
	AudioSource mAudio;

	public GameObject boomPrefabs;
	ParticleSystem psB;
	AudioSource mAudioB;

	public GameObject target;
	public float speed;
	public float minDist;
	float keepDist;

	public int targetHealth;

	void Start() {
		ps = hitSparkPrefabs.GetComponent<ParticleSystem> ();
		mAudio = hitSparkPrefabs.GetComponent<AudioSource> ();

		psB = boomPrefabs.GetComponent<ParticleSystem> ();
		mAudioB = boomPrefabs.GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.touchCount == 1 /* || Input.GetTouch (0).phase == TouchPhase.Began */){
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			Debug.DrawRay (ray.origin, ray.direction * rayDirection, Color.white);

				RayProcessing ();

				keepDist = Vector3.Distance (transform.position, target.transform.position);
				if (keepDist < minDist) {
					keepDist = minDist;
				}
		}
	}

	void RayProcessing() {
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask)) {	
			GameObject hitObject = hit.transform.gameObject;
			Debug.Log (hit.transform.gameObject.name);

			if (hitObject.CompareTag("object") == true) {
			
				targetHealth -= 1;

				GameObject hitSpark = Instantiate (hitSparkPrefabs);
				hitSpark.transform.position = hit.point;
				Destroy (hitSpark, 2);

				Vector3 dir = transform.position - target.transform.position;
				dir.Normalize ();
				target.transform.Translate (dir * speed * Time.deltaTime);

				if (targetHealth <= 0) {
					GameObject boom = Instantiate (boomPrefabs);
					boom.transform.position = transform.position;

					Destroy (hitObject);
			}
		}
	}
}
}
