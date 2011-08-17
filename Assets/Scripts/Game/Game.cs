
using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public const int MAX_LEVELS = 3;

//	private Player player;
//	public Player Player {
//		get {
//			if (player == null) {
//				player = new Player ();
//			}
//			
//			return player;
//		}
//	}

	private static Game instance;
	public static Game Instance {
		get { return instance; }
	}

	void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
//			Destroy(gameObject);	
		}
	}

	public void StartNewGame ()
	{
		Player.Instance.StartNewGame();
		LoadLevel (1);
	}

	public void LoadNextLevel ()
	{
		if (Level.CurrentLevel.LevelNumber == MAX_LEVELS)
		{
			Application.LoadLevel ("Game Over");
			return;
		}
		
		LoadLevel (Level.CurrentLevel.LevelNumber + 1);
	}

	private void LoadLevel (int levelNumber)
	{
		Application.LoadLevel ("Level " + levelNumber);
	}
}
