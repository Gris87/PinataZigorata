using UnityEngine;
using System.Collections;

public class SettingsMenuScript : MonoBehaviour
{
	public GameObject       mainMenu         = null;
	public BackButtonScript backButtonScript = null;

	public void show()
	{
		mainMenu.SetActive(false);

		gameObject.SetActive(true);
		backButtonScript.gameObject.SetActive(true);

		// TODO: Show settings menu
		//backButtonScript.show();
	}
}
