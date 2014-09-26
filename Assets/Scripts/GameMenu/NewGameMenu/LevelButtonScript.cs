using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonScript : MonoBehaviour
{
	private static float LEVEL_SELECTION_DELAY = 0.1f;



	public AudioSourceScript audioSourceScript = null;
	public float             showDelay         = 0f;

	private Animator mAnimator         = null;
	private Vector3  mOriginalPosition = new Vector3(0, 0, 0);
	private Vector2  mOriginalSize     = new Vector2(0, 0);

	private int  mLevelId = -1;



	private IEnumerator startShowAnimation()
	{
		yield return new WaitForSeconds(showDelay);
		mAnimator.SetTrigger(Global.SHOW_TRIGGER_HASH);
	}

	private IEnumerator startLevelSelection()
	{
		yield return new WaitForSeconds(LEVEL_SELECTION_DELAY);

		SceneManager.LoadScene("MainScene");
	}

	public void OnLevelPressed()
	{
		Debug.Log("Level " + mLevelId.ToString() + " selected");

		audioSourceScript.playClickClip();

		StartCoroutine(startLevelSelection());
	}

	void OnDisable()
	{
		// TODO: Solve problem with incorrect animation
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

	public void setLevelId(int id)
	{
		mLevelId = id;
		GetComponentInChildren<Text>().text = mLevelId.ToString();
	}
}
