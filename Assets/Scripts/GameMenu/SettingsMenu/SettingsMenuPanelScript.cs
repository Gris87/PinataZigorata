using UnityEngine;
using System.Collections;

public class SettingsMenuPanelScript : MonoBehaviour
{
	public float showDelay = 0f;
	public float hideDelay = 0f;
	
	private Animator mAnimator         = null;
	private Vector3  mOriginalPosition = new Vector3(-1000, 0, 0);
	
	
	
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
	
	public void hide()
	{
		StartCoroutine(startHideAnimation());
	}
	
	void OnDisable()
	{
		GetComponent<RectTransform>().localPosition = mOriginalPosition;
	}
	
	void OnEnable()
	{
		if (mOriginalPosition.x <= -1000)
		{
			mOriginalPosition = GetComponent<RectTransform>().localPosition;
		}
		
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}
		
		StartCoroutine(startShowAnimation());
	}
}
