﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditSceneLevelScript : MonoBehaviour
{
	public InputField          nameEdit            = null;
	public ImageSelectorScript imageSelectorScript = null;
	public Scrollbar           rowsScrollbar       = null;
	public Scrollbar           columnsScrollbar    = null;

	private string    mLevelFileName = "";
	private int       mLevelId       = 1;
	private LevelInfo mLevelInfo     = null;

	// Use this for initialization
	void Start()
	{
		Hashtable sceneArguments = SceneManager.sceneArguments;
		
		if (sceneArguments != null)
		{
			mLevelId = (int)sceneArguments[Extras.LEVEL_ID_EXTRA];
		}

		mLevelFileName = mLevelId.ToString();

		while (mLevelFileName.Length < 4)
		{
			mLevelFileName = '0' + mLevelFileName;
		}

		mLevelFileName = "Level " + mLevelFileName + ".xml";

		Debug.Log("Loading level : " + mLevelFileName);

#if UNITY_EDITOR
		mLevelInfo = LevelInfo.load(Application.dataPath + "/Resources/Levels/" + mLevelFileName);
#else
#endif

		// Applying loaded level
		nameEdit.text.text                = mLevelInfo.name;
		imageSelectorScript.selectedImage = mLevelInfo.background;
		rowsScrollbar.value               = (float)mLevelInfo.rows    / Global.LEVEL_MAX_HEIGHT;
		columnsScrollbar.value            = (float)mLevelInfo.columns / Global.LEVEL_MAX_WIDTH;
	}

	public void OnSavePressed()
	{
		Debug.Log("Save pressed");

		mLevelInfo.name       = nameEdit.text.text;
		mLevelInfo.background = imageSelectorScript.selectedImage;
		mLevelInfo.rows       = (int)(rowsScrollbar.value    * Global.LEVEL_MAX_HEIGHT);
		mLevelInfo.columns    = (int)(columnsScrollbar.value * Global.LEVEL_MAX_WIDTH);

#if UNITY_EDITOR
		mLevelInfo.save(Application.dataPath + "/Resources/Levels/" + mLevelFileName);
#else
#endif
	}
}
