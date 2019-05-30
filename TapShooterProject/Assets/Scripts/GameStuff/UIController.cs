using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	private ProgramController 	_progScript;
	private GameManager 		_gameScript;
	
	[SerializeField] private	Text 		timerText = null;
	private float 	timer = 0;
	private int 	seconds = 0;
	private int 	minutes = 0;
	
	
	public void 	SetVariables(ProgramController newProg, GameManager newGame)
	{
		_progScript = newProg;
		_gameScript = newGame;
	}
	
	
	public void 	CalcTime()
	{
		if (_gameScript.popsTouch == false)
			return;
		
		timer += Time.deltaTime;
		if (timer >= 1)
		{
			seconds += 1;
			timer = 0;
		}
		if (seconds >= 60)
		{
			minutes += 1;
			seconds = 0;
		}

		timerText.text = "Time: ";
		if (minutes < 10)
			timerText.text += "0" + minutes + ":";
		else
			timerText.text += minutes + ":";
		
		if (seconds < 10)
			timerText.text += "0" + seconds;
		else
			timerText.text += seconds;

//		timerText.text += ":" + timer * 10000000;
	}
	
	public float 	GetTime()
	{
		return seconds + minutes * 60 + timer;
	}	
	
	
	[SerializeField] private Text 	scoreText = null;
	public void 	SetScore(int score)
	{
		scoreText.text = "Score : " + score;
	}
	
	
	

	private bool 	pause = false;
	 
	public void     PauseGame()
	{
		pause = !pause;
		if (pause)
		{
			Time.timeScale = 0;
			_gameScript.popsTouch = false;
		}
		else
		{
			Time.timeScale = 1;
			_gameScript.popsTouch = true;
			
		}
	}
    
	public void     RestartGame()
	{
        _progScript.StartAGame();
	}
	
	public void 	FinishGame()
	{
		StartCoroutine(GameOver());
	}







	[SerializeField] private RectTransform 	_gameOverPanel = null;
	[SerializeField] private RectTransform 	_gameInfoPanel = null;
	[SerializeField] private RectTransform 	_gameButtons = null;
	
	[SerializeField] private Text 	_overTime = null;
	[SerializeField] private Text 	_overScore = null;

	public float 	gameOverDelay = 2;
	public IEnumerator 	GameOver()
	{
		_gameInfoPanel.gameObject.SetActive(false);
		_gameButtons.gameObject.SetActive(false);
		
		_gameOverPanel.gameObject.SetActive(true);
		_overTime.text = timerText.text;
		_overScore.text = scoreText.text;
		
		_gameScript.popsTouch = false;
		yield return new WaitForSeconds(gameOverDelay);
		_progScript.InitMenu();

		yield return null;
	}
	
}
