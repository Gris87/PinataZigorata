using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameScrollbarScript : MonoBehaviour
{
	public float showDelay = 0f;
	public float hideDelay = 0f;

	private Animator mAnimator      = null;
	private Color    mOriginalColor = new Color(0f, 0f, 0f, 0f);


	
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
		Scrollbar scrollbar = GetComponent<Scrollbar>();

		scrollbar.targetGraphic.color = mOriginalColor;
	}
	
	void OnEnable()
	{
		if (mOriginalColor.r <= 0)
		{
			Scrollbar scrollbar = GetComponent<Scrollbar>();
			
			mOriginalColor = scrollbar.targetGraphic.color;
		}
		
		if (mAnimator == null)
		{
			mAnimator = GetComponent<Animator>();
		}
		
		StartCoroutine(startShowAnimation());
	}
}
