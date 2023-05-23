using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("遊戲場景");
	}
	public void QuitGame() 
	{
		Application.Quit();
	}
}
