using UnityEngine;
using System.Collections;

public class SwitchMenuScript : MonoBehaviour
{
	public GameObject prevMenu   = null;
	public GameObject backButton = null;

	public void show()
	{
		prevMenu.SetActive(false);
		gameObject.SetActive(true);
		
		backButton.gameObject.SetActive(true);
	}
}
