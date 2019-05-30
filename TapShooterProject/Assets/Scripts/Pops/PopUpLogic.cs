using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpLogic : MonoBehaviour
{	
	[SerializeField] private Transform 		ownTransform = null;
	[SerializeField] private Animator 		ownAnimator = null;
	public GameManager		gameScript;

	public 	float 	vanishTime;
	private float 	timerToGo;
	
	private void 	Update()
	{
		DefaultBehavior();
	}
	
	private void OnMouseDown()
	{
		if (gameScript.popsTouch)
			PopupDisappear();
	}
	
	protected void 	DefaultBehavior()
	{
		timerToGo += Time.deltaTime;
		if (timerToGo >= vanishTime)
		{
			PopupVanish();
		}
	}
	
	private void 	PopupDisappear()
	{
		Debug.Log("Cube Pressed!!");

		gameScript.AddScore(5);
		Destroy(gameObject);
	}
	
	private void 	PopupVanish()
	{
		ownAnimator.SetBool("Expired", true);
		StartCoroutine(DelayedDestroy(1.5f));
	}
	
	private IEnumerator DelayedDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
		
		yield return null;
	}
}
