using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator m_animator;

	// Use this for initialization
	void Start ()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetTrigger("LeftIdle");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_animator.SetTrigger("LeftRun");
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_animator.SetTrigger("LeftIdle");
        }
	}
}
