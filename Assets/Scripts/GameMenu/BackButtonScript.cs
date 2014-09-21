using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour
{
	public float showDelay = 0f;
	public float hideDelay = 0f;
	
	private Animator mAnimator = null;
	
	
	
	private IEnumerator startShowAnimation()
	{
		yield return new WaitForSeconds(showDelay);
		mAnimator.SetTrigger(Global.SHOW_TRIGGER_HASH);
	}
	
	private IEnumerator startHideAnimation()
	{
		yield return new WaitForSeconds(hideDelay);
		mAnimator.SetTrigger(Global.HIDE_TRIGGER_HASH);
	}
	
	void OnEnable()
	{
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}
		
		StartCoroutine(startShowAnimation());
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
