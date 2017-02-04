using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementPlayer : MonoBehaviour {

    float m_speed = 1.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * m_speed * Time.deltaTime;
        }
    }
}
