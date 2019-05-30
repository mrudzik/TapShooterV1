using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramController : MonoBehaviour
{
	// Game Stuff
	
	[SerializeField] private GameManager 	_gamePrefab = null;
	[SerializeField] private Transform 		_gameHere = null;
	
	[SerializeField] private RectTransform 	_canvas = null;
	[SerializeField] private RectTransform 		_gameUIHere = null;
	
	
	private GameManager 	_currentGame;
	
	public void 	KillGame()
	{
		if (mainMenu != null)
			Destroy(mainMenu.gameObject);
		if (_currentGame == null)
			return;
		
		Destroy(_currentGame.gameObject);
		// Can be optimized!
		foreach (Transform UIChild in _gameUIHere)
		{
			Destroy(UIChild.gameObject);
		}
		
	}
	
	public void 	StartAGame()
	{
		KillGame();
		
		_currentGame = Instantiate(_gamePrefab, _gameHere);
		_currentGame.canvas = _gameUIHere;
		_currentGame.SetUpVariables(this);
		Time.timeScale = 1;

	}
	
	
	
	
	
	
	// Menu Stuff
	
	//    public url    DownLoadMenuLink;
	[SerializeField] private DownloadScript 	_downScript = null;
	[SerializeField] private RectTransform 		_mainMenuHere = null;
	private MainMenuController mainMenuPrefab;
	private MainMenuController mainMenu;
	
	
	public void 	InitMenu()
	{
		mainMenuPrefab = _downScript.GetMenu();
		if (mainMenuPrefab == null)
		{
			Debug.Log("Main menu prefab is not downloaded!");
			return;
		}
		
		
		KillGame();
		
		mainMenu = Instantiate(mainMenuPrefab, _mainMenuHere);
		mainMenu.SetProgScript(this);
	}


}
