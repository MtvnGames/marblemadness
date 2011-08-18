using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public const int STARTING_LIVES = 3;
	
	private GameObject marble;
	public GameObject Marble
	{
		get
		{
			if(marble == null)
			{
				marble = GameObject.FindGameObjectWithTag("Player");
			}
			
			return marble;
		}
	}
	
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
			if(controller == null)
			{
				controller = Marble.GetComponent("ConstantForceController") as ConstantForceController;
			}
			
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
	
	public void Start()
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
	

	public void Respawn()
	{
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn") as GameObject;
		
		// move the marble to the respawn 
		Marble.transform.position = respawn.transform.position;
			
		// cancel/cease any movement
		Marble.constantForce.force = Vector3.zero;
		Marble.rigidbody.velocity = Vector3.zero;
	}
}
