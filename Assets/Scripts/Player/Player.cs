using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public const int STARTING_LIVES = 3;
	
	private GameObject marble;
	
	public int score = 0;
	public int Score
	{
		get 
		{
			return score;
		}
		set
		{
			score = value;
		}
	}
	
	private ConstantForceController controller;
	public ConstantForceController Controller
	{
		get
		{
			return controller;
		}				
	}
	
	private int lives = STARTING_LIVES;
	public int Lives
	{
		get
		{
			return lives;
		}
	}
	
	private static Player instance;
	public static Player Instance 
	{
		get { return instance; }
	}

	void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
		}
		else
		{
			DestroyImmediate(this);	
		}
	}
	
	public void Die()
	{
		lives--;
		
		if (lives == 0)
		{
			Application.LoadLevel("Game Over");
		}
		else
		{
			Level.CurrentLevel.StartLevel();
			Respawn();
		}
	}
	
	public void StartNewGame()
	{
		lives = STARTING_LIVES;	
		score = 0;
	}
	
	public void Update()
	{
		if(controller && controller.Enabled)
		{
			score += 1;	
		}
	}
	
	public void OnLevelWasLoaded(int levelIndex)
	{
		marble = GameObject.FindGameObjectWithTag("Player");
		if(marble)
		{
			controller = marble.GetComponent("ConstantForceController") as ConstantForceController;
		}
	}
	
	public void Respawn()
	{
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn") as GameObject;
		
		// move the marble to the respawn 
		marble.transform.position = respawn.transform.position;
		
		// cancel/cease any movement
		marble.constantForce.force = Vector3.zero;
		marble.rigidbody.velocity = Vector3.zero;
	}
}
