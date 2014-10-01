using UnityEngine;
using System.Collections;

public class EditSceneBackButtonScript : MonoBehaviour
{
	public void OnBackPressed()
	{
		Debug.Log("Back pressed");

		Hashtable data = new Hashtable();
		data.Add(Extras.PREVIOUS_SCENE_EXTRA, Global.EDIT_SCENE_NAME);		
		SceneManager.LoadScene(Global.GAME_MENU_SCENE_NAME, data);
	}
}
