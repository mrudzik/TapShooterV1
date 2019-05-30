using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private ProgramController     progScript;
    
    public void     SetProgScript(ProgramController newProgScript)
    {
        progScript = newProgScript;
    }
    
    
    public void     StartAGame()
    {
        if (progScript != null)
        {
            progScript.StartAGame();
        }
        else
            Debug.Log("Menu is not correctly initialized!");
    }
    
   

}
