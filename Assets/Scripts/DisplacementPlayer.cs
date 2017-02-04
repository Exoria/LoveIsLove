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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * m_speed * Time.deltaTime;
        }
    }
}
