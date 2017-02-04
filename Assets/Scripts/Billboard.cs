using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update() 
	{
		Vector3 pos = new Vector3();
		pos += transform.position + Camera.main.transform.forward;
		transform.LookAt(pos, Vector3.up);
	}
}
