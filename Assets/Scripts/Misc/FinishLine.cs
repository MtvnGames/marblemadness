using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Finish!");	
		
		Player.Instance.Controller.Enabled = false;
		Player.Instance.Controller.ClearForceAndVelocity();
		
		AsyncOperation async = Application.LoadLevelAdditiveAsync("Level Summary");
//		yield return async;
		
//		yield return new WaitForSeconds(6.0f);
		
//		Game.Instance.LoadNextLevel();
	}	
}
