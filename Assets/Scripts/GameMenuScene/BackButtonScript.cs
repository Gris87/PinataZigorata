using UnityEngine;
using System.Collections;

public class BackButtonScript : MonoBehaviour
{
	public AudioSourceScript       audioSourceScript        = null;
	public GameObject              newGameMenu              = null;
	public NewGameScrollbarScript  newGameScrollbarScript   = null;
	public SwitchMenuScript        newGameSwitchMenuScript  = null;
	public GameObject              settingsMenu             = null;
	public SettingsMenuPanelScript settingsMenuPanelScript  = null;
	public SwitchMenuScript        settingsSwitchMenuScript = null;
	public float                   showDelay                = 0f;
	public float                   hideDelay                = 0f;
	public float                   menuDelay                = 0f;
	
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

	private IEnumerator startSwithingFromNewGameMenuToMainMenu()
	{
		yield return new WaitForSeconds(menuDelay);
		newGameSwitchMenuScript.goBack();
	}

	private IEnumerator startSwithingFromSettingsMenuToMainMenu()
	{
		yield return new WaitForSeconds(menuDelay);
		settingsSwitchMenuScript.goBack();
	}

	public void OnBackPressed()
	{
		Debug.Log("Back pressed");
		
		audioSourceScript.playClip();
		StartCoroutine(startHideAnimation());
		
		if (newGameMenu.activeSelf)
		{
			newGameScrollbarScript.hide();
			StartCoroutine(startSwithingFromNewGameMenuToMainMenu());
		}
		else
		if (settingsMenu.activeSelf)
		{
			settingsMenuPanelScript.hide();
			StartCoroutine(startSwithingFromSettingsMenuToMainMenu());
		}
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
