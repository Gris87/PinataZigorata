using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateNewGameContentScript : MonoBehaviour
{
	public AudioSourceScript audioSourceScript = null;
	public Transform         targetTransform   = null;
	public Button            buttonPrefab      = null;
	public int               buttonOffsetX     = 60;
	public int               buttonOffsetY     = 60;
	public int               buttonSpacingX    = 60;
	public int               buttonSpacingY    = 60;
	public int               buttonWidth       = 300;
	public int               buttonHeight      = 300;
	public int               columnCount       = 5;
	public float             showDelay         = 0.05f;



	// Use this for initialization
	void Start()
	{
		Object[] levels = Resources.LoadAll("Levels");

		RectTransform scrollRect = targetTransform.GetComponent<RectTransform>();
		scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, buttonOffsetY + (buttonHeight + buttonSpacingY) * (Mathf.FloorToInt((levels.Length + columnCount - 1) / (float)columnCount)));

		for (int i=0; i<levels.Length; ++i)
		{
			int column = i % columnCount;
			int row    = (i - column) / columnCount;

			GameObject levelButton = Instantiate(buttonPrefab.gameObject) as GameObject;
			
			levelButton.transform.SetParent(targetTransform);

			RectTransform buttonRect    = levelButton.GetComponent<RectTransform>();
			
			buttonRect.pivot            = new Vector2(0.5f, 0.5f);
			buttonRect.anchoredPosition = new Vector2(0, 0);
			buttonRect.localPosition    = new Vector3(buttonOffsetX + buttonWidth / 2 + (buttonWidth + buttonSpacingX) * column, -buttonOffsetY - buttonHeight / 2 - (buttonHeight + buttonSpacingY) * row, 0);
			buttonRect.sizeDelta        = new Vector2(buttonWidth, buttonHeight);
			buttonRect.localScale       = new Vector3(1, 1, 1);

			LevelButtonScript levelButtonScript = levelButton.GetComponent<LevelButtonScript>();
			levelButtonScript.setLevelId(i+1);
			levelButtonScript.audioSourceScript = audioSourceScript;
			levelButtonScript.showDelay         = i * showDelay;
			levelButtonScript.enabled           = true;
		}
	}
}
