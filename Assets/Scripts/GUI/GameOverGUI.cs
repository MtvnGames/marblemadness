using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {
	
	const int BUTTON_HEIGHT = 50;
	const int BUTTON_WIDTH = 84;
	
	public Texture2D background;
	
	void OnGUI() 
	{
		if(background)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		}
		
		if(GUI.Button(new Rect((Screen.width - BUTTON_WIDTH) / 2, (Screen.height + BUTTON_HEIGHT) / 2, BUTTON_WIDTH, BUTTON_HEIGHT), "Play Again"))
		{
			Application.LoadLevel("Main Menu");
		}
	}
}
