using UnityEngine;
using System.Collections;

public class NewGameMenuScript : MonoBehaviour
{
	public NewGameScrollRectScript newGameScrollRectScript = null;
	public BackButtonScript        backButtonScript        = null;

	public void show()
	{
		gameObject.SetActive(true);
		backButtonScript.gameObject.SetActive(true);

		newGameScrollRectScript.show();
		backButtonScript.show();
	}
}
