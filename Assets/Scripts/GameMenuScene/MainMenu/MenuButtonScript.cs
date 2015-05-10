#define MENU_BUTTON_DEBUG

using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour
{
    public Transform         mainMenu          = null;
    public SwitchMenuScript  nextMenu          = null;
    public AudioSourceScript audioSourceScript = null;
    public float             showDelay         = 0f;
    public float             hideDelay         = 0f;
    public float             menuDelay         = 0f;

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

    private IEnumerator startSwithingToNextMenu()
    {
        yield return new WaitForSeconds(menuDelay);
        nextMenu.goNext();
    }

    private void hide()
    {
        for (int i=0; i<mainMenu.childCount; ++i)
        {
            MenuButtonScript menuButtonScript = mainMenu.GetChild(i).GetComponent<MenuButtonScript>();

            if (menuButtonScript)
            {
                StartCoroutine(menuButtonScript.startHideAnimation());
            }
        }
    }

    private void exitApp()
    {
#if MENU_BUTTON_DEBUG
        Debug.Log("Application finished");
#endif

        Application.Quit();
    }

    public void OnNewGameClicked()
    {
#if MENU_BUTTON_DEBUG
        Debug.Log("New game pressed");
#endif

        audioSourceScript.playClip();
        hide();

        StartCoroutine(startSwithingToNextMenu());
    }

    public void OnSettingsClicked()
    {
#if MENU_BUTTON_DEBUG
        Debug.Log("Settings pressed");
#endif

        audioSourceScript.playClip();
        hide();

        StartCoroutine(startSwithingToNextMenu());
    }

    public void OnExitClicked()
    {
        audioSourceScript.playClip();
        exitApp();
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
        // TODO: Uncomment it
        /*
        if (InputControl.GetKeyDown(KeyCode.Escape))
        {
            exitApp();
        }
        */
    }
}
