using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ON_Load : MonoBehaviour
{
	
	public GameObject menu;
	public GameObject loadingInterface;
	public Image progressbar;
	public TextMeshPro text;
	
	List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
	

	public void StartGame()
	{
		HideMenu();
		ShowLoadingScreen();
		scenesToLoad.Add(SceneManager.LoadSceneAsync("SampleScene"));
		scenesToLoad.Add(SceneManager.LoadSceneAsync("StartingArea", LoadSceneMode.Additive));
		StartCoroutine(LoadingScrene());
		
		
	}
	public void HideMenu()
	{
		menu.SetActive(false);
	}
	public void ShowLoadingScreen()
	{
		loadingInterface.SetActive(true);
	}
	
	public IEnumerator LoadingScrene()
	{
		float totalProgress =0f;
		for(int i =0; i<scenesToLoad.Count;++i)
		{
			totalProgress += scenesToLoad[i].progress;
			progressbar.fillAmount = totalProgress/scenesToLoad.Count;
			yield return null;
		}
	}
	public void ExitGame(){
		Application.Quit();
	}
	
   
}
