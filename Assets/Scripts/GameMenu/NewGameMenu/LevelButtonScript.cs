using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonScript : MonoBehaviour
{
	public AudioSourceScript audioSourceScript = null;

	private Text mText    = null;
	private int  mLevelId = -1;



	public void OnLevelPressed()
	{
		Debug.Log("Level " + mLevelId.ToString() + " selected");

		audioSourceScript.playClickClip();
	}

	public void setLevelId(int id)
	{
		mLevelId = id;

		if (mText == null)
		{
			mText = GetComponentInChildren<Text>();
		}

		mText.text = mLevelId.ToString();
	}
}
