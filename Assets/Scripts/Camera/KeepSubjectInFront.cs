using UnityEngine;
using System.Collections;

public class KeepSubjectInFront : MonoBehaviour
{
	public Transform target;
	float distance = 15;
		
	void LateUpdate () 
	{
		transform.position  = new Vector3(transform.position.x, transform.position.y, target.position.z + distance);
	}

}