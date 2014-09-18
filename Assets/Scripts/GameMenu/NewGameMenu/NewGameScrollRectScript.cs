using UnityEngine;
using System.Collections;

public class NewGameScrollRectScript : MonoBehaviour
{
	private Animator mAnimator = null;


	private Animator getAnimator()
	{
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}

		return mAnimator;
	}

	/*
	public void show()
	{
		getAnimator().SetTrigger(Global.SHOW_TRIGGER_HASH);
	}

	public void hide()
	{
		getAnimator().SetTrigger(Global.HIDE_TRIGGER_HASH);
	}
	*/

	void Enable()
	{
		StartCoroutine()
	}
}
