using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopNegativeLogic : PopUpLogic
{
    // OverRidden from PopUpLogic
    private void 	Update()
    {
        DefaultBehavior();
        NegativeBehavior();
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
        Debug.Log("Negative Cube Pressed!!");
        gameScript.AddScore(-50);
        Destroy(gameObject);
    }
	
	
	
    private void     NegativeBehavior()
    {
        // Something Special here
		
		
    }
}
