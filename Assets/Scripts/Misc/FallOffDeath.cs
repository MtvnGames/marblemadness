using UnityEngine;
using System.Collections;

public class FallOffDeath : MonoBehaviour 
{
	public GameObject respawn;
	
	private Player player;
		
	void OnTriggerEnter(Collider other)
	{
		Player.Instance.Die();
		Level.CurrentLevel.StartLevel();
	}
}
