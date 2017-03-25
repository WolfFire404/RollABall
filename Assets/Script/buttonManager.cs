using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour 
{
	void Start()
	{
		Cursor.visible = true;
	}
	public void newGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);	
	}

	public void ExitGameBtn()
	{
		Application.Quit ();
	}
}
