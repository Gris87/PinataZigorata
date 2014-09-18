using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour
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
	
	public void show()
	{
		getAnimator().SetTrigger(Global.SHOW_TRIGGER_HASH);
	}
	
	public void hide()
	{
		getAnimator().SetTrigger(Global.HIDE_TRIGGER_HASH);
	}

	public void OnBackPressed()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		// TODO: Go back on Escape
		/*
        if (InputControl.GetKeyDown(KeyCode.Escape))
        {
        	OnBackPressed();
        }
		*/
	}
}
