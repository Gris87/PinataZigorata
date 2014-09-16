using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonScript : MonoBehaviour
{
	private Text mText    = null;
	private int  mLevelId = -1;

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
