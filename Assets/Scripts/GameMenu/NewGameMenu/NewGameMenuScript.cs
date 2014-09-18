using UnityEngine;
using System.Collections;

public class NewGameMenuScript : MonoBehaviour
{
	public GameObject              mainMenu                = null;
	public NewGameScrollRectScript newGameScrollRectScript = null;
	public BackButtonScript        backButtonScript        = null;

	public void show()
	{
		mainMenu.SetActive(false);

		gameObject.SetActive(true);
		backButtonScript.gameObject.SetActive(true);

		//newGameScrollRectScript.show();
		//backButtonScript.show();
	}
}
