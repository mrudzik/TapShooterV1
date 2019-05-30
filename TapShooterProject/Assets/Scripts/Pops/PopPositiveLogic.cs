using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopPositiveLogic : PopUpLogic
{
	
	// Update is called once per frame
	// OverRidden from PopUpLogic
	private void 	Update()
	{
		DefaultBehavior();
		PositiveBehavior();
	}
	
	// OverRidden from PopUpLogic
	private void 	OnMouseDown()
	{
		if (gameScript.popsTouch)
			PopupDisappear();
	}

	// OverRidden from PopUpLogic
	private void  	PopupDisappear()
	{
		Debug.Log("Positive Cube Pressed!!");

		gameScript.AddScore(50);
		Destroy(gameObject);
	}
	
	
	
	private void     PositiveBehavior()
	{
		// Something Special here
		
		
	}
}
