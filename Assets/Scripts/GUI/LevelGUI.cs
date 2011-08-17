using UnityEngine;
using System.Collections;

public class LevelGUI : MonoBehaviour 
{
	public Countdown CountdownPrefab;
	
	private Countdown countdown;
	public Countdown Countdown
	{
		get
		{
			return countdown;
		}
	}
	
	private static LevelGUI instance = null;
	public static LevelGUI Instance
	{
		get
		{
			return instance;
		}
	}
	
	void Awake()
	{
	}
		
	void Start()
	{
		instance = this;
		countdown = Instantiate(CountdownPrefab, Vector3.one, Quaternion.identity) as Countdown;
	}
	
	void OnGUI() 
	{
		GUI.Label(new Rect(10, 10, 200, 20), "Level: " + Level.CurrentLevel.LevelNumber);
		GUI.Label(new Rect(Screen.width / 2, 25, 50, 20), Level.CurrentLevel.TimeLeft.ToString());
		GUI.Label(new Rect(10, 25, 200, 20), "Lives: " + Player.Instance.Lives);
		
		GUI.Label(new Rect(Screen.width - 50, 10, 100, 20), "Score");
		GUI.Label(new Rect(Screen.width - 50, 25, 100, 20), Player.Instance.Score.ToString());
	}
}
