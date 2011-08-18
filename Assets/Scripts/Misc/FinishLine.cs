using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	IEnumerator OnTriggerEnter(Collider other)
	{
		Debug.Log("Finish!");	
		
		yield return new WaitForSeconds(1.0f);
		
		Player.Instance.Controller.Enabled = false;
		Player.Instance.Controller.ClearForceAndVelocity();
		
		Game.Instance.LoadNextLevel();
	}	
}
