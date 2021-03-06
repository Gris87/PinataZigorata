#define LEVEL_BUTTON_DEBUG

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelButtonScript : MonoBehaviour
{
    private static float LEVEL_SELECTION_DELAY = 0.2f;


// TODO: pointer to parent
    public AudioSourceScript audioSourceScript = null;
    public Toggle            editToggle        = null;
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

        Hashtable levelData = new Hashtable();
        levelData.Add(Extras.LEVEL_ID_EXTRA, mLevelId);

        if (editToggle.isOn)
        {
            SceneManager.LoadScene(Global.EDIT_SCENE_NAME, levelData);
        }
        else
        {
            SceneManager.LoadScene(Global.MAIN_SCENE_NAME, levelData);
        }
    }

    public void OnLevelPressed()
    {
#if LEVEL_BUTTON_DEBUG
        Debug.Log("Level " + mLevelId.ToString() + " selected");
#endif

        audioSourceScript.playClip();

        StartCoroutine(startLevelSelection());
    }

    void OnDisable()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (rectTransform)
        {
            rectTransform.localPosition = mOriginalPosition;
            rectTransform.sizeDelta     = mOriginalSize;
        }
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

        for (int i=0; i<transform.childCount; ++i)
        {
            Text text = transform.GetChild(i).GetComponent<Text>();

            if (text)
            {
                text.text = mLevelId.ToString();
            }
        }
    }
}
