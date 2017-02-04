using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

	float nextChangeDir = 0.0f;
	float dir = 0.0f;
	int lastanimdir = -1;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		// random direction decision
		nextChangeDir -= Time.deltaTime;

		if (nextChangeDir <= 0.0f) {
			nextChangeDir = Random.Range (1.0f, 3.0f);
			dir = Random.Range (0.0f, Mathf.PI * 2.0f);
		}

		// update position according to dir
		float speed = Time.deltaTime * 0.4f;

		Vector3 npos = new Vector3 ();
		npos = transform.position;

		npos.x += Mathf.Cos (dir) * speed;
		npos.z += Mathf.Sin (dir) * speed;

		transform.position = npos;

		// give correct anim relative to camera and dir
		float camDir = Mathf.Atan2(Camera.main.transform.forward.x, Camera.main.transform.forward.z);
		if (camDir < 0.0f)
			camDir += 2.0f * Mathf.PI;
		float dirAdd = ((camDir + dir) * 180.0f / Mathf.PI + 45.0f) / 90.0f;

		int animdir = (((int) dirAdd) + 8) % 4;
		if (animdir != lastanimdir) {
			//GetComponent<Animator> ().SetInteger ("direction", animdir);
			switch (animdir) {
			case 0:
				GetComponent<Animator> ().SetTrigger ("goright");
				break;
			case 1:
				GetComponent<Animator> ().SetTrigger ("goup");
				break;
			case 2:
				GetComponent<Animator> ().SetTrigger ("goleft");
				break;
			case 3:
				GetComponent<Animator> ().SetTrigger ("godown");
				break;
			}
			lastanimdir = animdir;
		}
	}
}
