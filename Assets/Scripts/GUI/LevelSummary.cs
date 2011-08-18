using UnityEngine;
using System.Collections;

public class LevelSummary : MonoBehaviour {
	
	public static int BONUS_MULTIPLIER = 100;
	
	public SpriteText bonusLabel;
	
	public SpriteText timeLabel;
	
	private int totalBonus = 0;
	
	private int currentBonusDisplay = 0;
	
	private bool accumulateBonus = false;
		
	IEnumerator Start () 
	{
		timeLabel.Text = "";
		bonusLabel.Text = "";
		
		yield return new WaitForSeconds(1.0f);
		
		int timeToFinish = Level.CurrentLevel.TimeToFinish - Level.CurrentLevel.TimeLeft;
		totalBonus = timeToFinish * BONUS_MULTIPLIER;
		timeLabel.Text = "Time: " + timeToFinish + " secs";
		
		yield return new WaitForSeconds(1.0f);
		
		bonusLabel.Text = "Bonus: 0";
		
		yield return new WaitForSeconds(1.0f);
		
		accumulateBonus = true;
	}
	
	void Update () 
	{
		if(accumulateBonus)
		{
			if(currentBonusDisplay <= totalBonus)
			{
				bonusLabel.Text = "Bonus: " + currentBonusDisplay;
				currentBonusDisplay += 5;
			}
			else
			{
				Player.Instance.Score += totalBonus;
				Game.Instance.LoadNextLevel();
			}
		}
	}
}
