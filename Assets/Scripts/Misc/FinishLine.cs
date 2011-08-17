using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Finish!");	
		
		ConstantForceController cfc = other.GetComponent("ConstantForceController") as ConstantForceController;
		cfc.ClearForceAndVelocity();
		
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn") as GameObject;
		other.transform.position = respawn.transform.position;
		other.constantForce.force = Vector3.zero;
		
		//TODO: Show some level ending GUI
		
		Game.Instance.LoadNextLevel();
	}	
}
