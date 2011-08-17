using UnityEngine;
using System.Collections;
using System;

public delegate void CompleteEventHandler(object sender, EventArgs e);

public class Countdown : MonoBehaviour 
{
	public int startAt = 3;
	
	private int currentCount;
	
	private SpriteText spriteText;
	
	public event CompleteEventHandler Completed;
		
	void Start () 
	{
		spriteText = GetComponent("SpriteText") as SpriteText;
		iTween.Init(gameObject);
	}
	
	public void StartCountdown()
	{
		currentCount = startAt;			
		ShowNextCount();
	}
	
	private void ShowNextCount()
	{
		//TODO: Why can't spriteText be found in Start() or Awake()
		if(!spriteText)
		{
			spriteText = GetComponent("SpriteText") as SpriteText;
		}
		
		// update text
		spriteText.Text = currentCount.ToString();
		
		// perform animation
		iTween.ScaleBy(gameObject, iTween.Hash("amount", new Vector3(2.0f, 2.0f, 1.0f), "time", 1.0f, "oncomplete", "OnCount", "looptype", iTween.LoopType.loop));
		iTween.FadeTo(gameObject, iTween.Hash("alpha", 0.0f, "time", 1.0f, "looptype", iTween.LoopType.loop));
	}
	
	private void OnCount()
	{
		currentCount--;
		
		if(currentCount == 0)
		{
			OnComplete();
			return;
		}
		
		ShowNextCount();		
	}
	
	private void OnComplete()
	{
		print("Countdown.OnComplete");
		
		iTween.Stop(gameObject);
			
		if(Completed != null)
		{
			print("Countdown.OnComplete Callback");
			Completed(this, EventArgs.Empty);
		}
	}
}
