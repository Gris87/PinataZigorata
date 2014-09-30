using UnityEngine;
using System.Collections;

public class GameMenuInitializerScript : MonoBehaviour
{
	public GameObject editToggle = null;

	// Use this for initialization
	void Start()
	{
		Hashtable sceneArguments = SceneManager.sceneArguments;

		if (sceneArguments != null)
		{
			string previousScene = (string)sceneArguments[Extras.PREVIOUS_SCENE_EXTRA];
			editToggle.SetActive(previousScene.Equals("EditScene"));
		}
		else
		{
			editToggle.SetActive(!Build.Release);
		}
	}
}
