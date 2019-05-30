using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	

	
	
	[SerializeField] 	private UIController 		uiScriptPrefab = null;
	private ProgramController 	_progScript;
	
	public RectTransform 	canvas;
	private UIController 	uiScript;

	private void Update()
	{
		uiScript.CalcTime();
		uiScript.SetScore(_score);
		GameLogic();
		
	}

	
	
	
	
	public void 	SetUpVariables(ProgramController newProg)
	{
		uiScript = Instantiate(uiScriptPrefab, canvas);

		_progScript = newProg;
		uiScript.SetVariables(_progScript, this);

	}






	public float 	timeToFinish = 60;
	
	public float 	timeDelay = 0.5f;
	private float 	_secondsSpend;
	private void 	GameLogic()
	{
		float localTime = uiScript.GetTime();
		
		
		if (localTime > _secondsSpend + timeDelay)
		{
			_secondsSpend = localTime;
			SpawnPopRandom();
		}
		
		CheckFinish(localTime);
		
	}
	
	
	[SerializeField] private PopUpLogic 		_popUpPrefab = null;
	[SerializeField] private PopNegativeLogic 	_popNegPrefab = null;
	[SerializeField] private PopPositiveLogic 	_popPosPrefab = null;
	
	[SerializeField] private Transform 		_popsHere = null;

	
	public float 	spawnXBorder = 0;
	public float 	spawnYBorder = 0;
	public float 	vanishTime = 0;


	public bool 	popsTouch = true;
	
	private void 	SpawnPopRandom()
	{
		Vector3 	popPos = new Vector3(Random.Range(-spawnXBorder, spawnXBorder), Random.Range(-spawnYBorder, spawnYBorder), 0);
		int 		rand = Random.Range(0, 5);

		
		if (rand == 4)
		{
			var tempPop = Instantiate(_popNegPrefab, _popsHere);
			
			tempPop.transform.position = popPos;
			tempPop.gameScript = this;
			tempPop.vanishTime = vanishTime;
		}
		else if (rand == 0)
		{
			var tempPop = Instantiate(_popPosPrefab, _popsHere);

			tempPop.transform.position = popPos;
			tempPop.gameScript = this;
			tempPop.vanishTime = vanishTime;
		}
		else
		{
			var	tempPop = Instantiate(_popUpPrefab, _popsHere);

			tempPop.transform.position = popPos;
			tempPop.gameScript = this;
			tempPop.vanishTime = vanishTime;
		}

	}


	
	
	
	private void 	CheckFinish(float spentTime)
	{
		if (spentTime < 60)
			return;

		StartCoroutine(uiScript.GameOver());
	}
	
	
	
	
	
	
	
	
	
	private int _score = 0;
	
	public void 	AddScore(int toAdd)
	{
		_score += toAdd;
	}
}
