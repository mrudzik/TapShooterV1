using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadScript : MonoBehaviour
{
//	public string     menuURL;
	
	
	private MainMenuController downloadedMenu = null;
	public MainMenuController menuPrefab;
	public MainMenuController     GetMenu()
	{
		if (downloadedMenu == null)
		{
			Debug.Log("The menu is gone!");
			return menuPrefab;
		}
		
		Debug.Log("Menu alive");	
		return downloadedMenu;
	}
	
    public void     DownloadMenu()
    {
        StartCoroutine(DownLoadMenuRoutine());
    }

    private string 	bundleURL = "ftp://a3print@ftp.s13.freehost.com.ua/public_html/menumain.unity3d";
    private int 	version = -1;
    
    private IEnumerator DownLoadMenuRoutine()
    {
	    Debug.Log("Checking Caching");
	    while (!Caching.ready)
		    yield return null;
	    Debug.Log("Caching is fine");

	    
	    Debug.Log("Loading Asset Bundle");
	    var www = WWW.LoadFromCacheOrDownload(bundleURL, version);
	    
	    yield return www;
	    
	    if (!string.IsNullOrEmpty(www.error))
	    {
		    Debug.Log(www.error);
		    yield break;
	    }
	    Debug.Log("Loaded Asset Bundle");

	    var assetBundle = www.assetBundle;
	    string menuName = "MainMenuTemp.prefab";

	    Debug.Log("Unpacking Prefab");
	    var prefabRequest = assetBundle.LoadAssetAsync<GameObject>(menuName);
	    yield return prefabRequest;
		Debug.Log("Prefab Unpacked");
		
		downloadedMenu = prefabRequest.asset as MainMenuController;
		



    }



}
