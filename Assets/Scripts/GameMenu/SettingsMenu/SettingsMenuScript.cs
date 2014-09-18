using UnityEngine;
using System.Collections;

public class SettingsMenuScript : MonoBehaviour
{
	public BackButtonScript backButtonScript = null;

	public void show()
	{
		gameObject.SetActive(true);
		backButtonScript.gameObject.SetActive(true);

		// TODO: Show settings menu
		backButtonScript.show();
	}
}
