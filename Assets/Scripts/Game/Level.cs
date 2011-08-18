using UnityEngine;
using System.Collections;
using System;

public class Level : MonoBehaviour 
{
	public const string GUI_LEVEL_NAME = "Level GUI";
	
	public int TimeToFinish = 60;
	
	public int LevelNumber = -1;
	
	private float timeLevelStarted = 0;
	
	private bool hasStarted = false;
	public bool HasStarted
	{
		get {
			return hasStarted;
		}
	}
	
	private static Level currentLevel;
	public static Level CurrentLevel
	{
		get
		{
			return currentLevel;
		}
	}
		
	public int TimeLeft
	{
		get
		{
			if(timeLevelStarted <= 0)
			{
				return TimeToFinish;
			}
			return Mathf.RoundToInt(Mathf.Max(-1, TimeToFinish - (Time.time - timeLevelStarted)));
		}
	}

	public IEnumerator Start()
	{
		print("Level.Start");
		currentLevel = this;
		hasStarted = false;
		
		if(LevelNumber > 0)
		{
			print("Level.LoadGUI");
			
			AsyncOperation async = Application.LoadLevelAdditiveAsync(GUI_LEVEL_NAME);
			yield return async;
			
			print("Level.GUILoaded");
			currentLevel = this;
		}
		
		if(LevelGUI.Instance)
		{
			StartLevel();
		}
	}
		
	private void CountdownCompleted(object sender, EventArgs args)
	{
		print("Level.CountdownCompleted");
		timeLevelStarted = Time.time;
		hasStarted = true;
		Player.Instance.Controller.Enabled = true;
	}
	
	public void StartLevel()
	{
		print("Level.StartLevel");
		Player.Instance.Controller.Enabled = false;
		
		LevelGUI.Instance.Countdown.Completed += new CompleteEventHandler(CountdownCompleted);
		LevelGUI.Instance.Countdown.StartCountdown();
	}
	
	void FixedUpdate ()
	{
		// check for out of time
		if (hasStarted && TimeLeft == 0) 
		{
			Player.Instance.Die ();
			
			if (Player.Instance.Lives > 0)
			{
				StartLevel();
			}
		}
	}
	
}
