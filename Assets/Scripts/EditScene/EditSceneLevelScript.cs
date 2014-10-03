using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditSceneLevelScript : MonoBehaviour
{
	public InputField nameEdit         = null;
	public Scrollbar  rowsScrollbar    = null;
	public Scrollbar  columnsScrollbar = null;

	private int mLevelId = 1;

	// Use this for initialization
	void Start()
	{
		Hashtable sceneArguments = SceneManager.sceneArguments;
		
		if (sceneArguments != null)
		{
			mLevelId = (int)sceneArguments[Extras.LEVEL_ID_EXTRA];
		}

		Debug.Log("Loading level " + mLevelId.ToString());
	}

	public void OnSavePressed()
	{
		Debug.Log("Save pressed");
	}
}
