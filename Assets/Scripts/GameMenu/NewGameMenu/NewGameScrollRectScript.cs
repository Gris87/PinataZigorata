using UnityEngine;
using System.Collections;

public class NewGameScrollRectScript : MonoBehaviour
{
	private static int SHOW_TRIGGER_HASH = Animator.StringToHash("Show");
	private static int HIDE_TRIGGER_HASH = Animator.StringToHash("Hide");


	
	private Animator mAnimator = null;


	private Animator getAnimator()
	{
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}

		return mAnimator;
	}

	public void show()
	{
		getAnimator().SetTrigger(SHOW_TRIGGER_HASH);
	}

	public void hide()
	{
		getAnimator().SetTrigger(HIDE_TRIGGER_HASH);
	}
		
	// Update is called once per frame
	void Update()
	{
		// TODO: Go back on Escape
		/*
        if (InputControl.GetKeyDown(KeyCode.Escape))
        {
        }
		*/
	}
}
