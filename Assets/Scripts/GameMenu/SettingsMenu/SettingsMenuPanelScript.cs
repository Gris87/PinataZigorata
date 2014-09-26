using UnityEngine;
using System.Collections;

public class SettingsMenuPanelScript : MonoBehaviour
{
	public float showDelay = 0f;
	public float hideDelay = 0f;
	
	private Animator mAnimator         = null;
	private Vector3  mOriginalPosition = new Vector3(0, 0, 0);
	private Vector2  mOriginalSize     = new Vector2(0, 0);
	
	
	
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
		RectTransform rectTransform = GetComponent<RectTransform>();

		rectTransform.localPosition = mOriginalPosition;
		rectTransform.sizeDelta     = mOriginalSize;
	}
	
	void OnEnable()
	{
		if (mOriginalSize.x <= 0)
		{
			RectTransform rectTransform = GetComponent<RectTransform>();
			
			mOriginalPosition = rectTransform.localPosition;
			mOriginalSize     = rectTransform.sizeDelta;
		}
		
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}
		
		StartCoroutine(startShowAnimation());
	}
}
