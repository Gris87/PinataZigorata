using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateNewGameContentScript : MonoBehaviour
{
	public AudioSourceScript audioSourceScript = null;
	public Button            buttonPrefab      = null;
	public int               buttonOffsetX     = 20;
	public int               buttonOffsetY     = 20;
	public int               buttonSpacingX    = 20;
	public int               buttonSpacingY    = 20;
	public int               buttonWidth       = 100;
	public int               buttonHeight      = 100;
	public int               columnCount       = 5;



	// Use this for initialization
	void Start()
	{
		Object[] levels = Resources.LoadAll("Levels");

		RectTransform scrollRect = GetComponent<RectTransform>();
		scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, buttonOffsetY + (buttonHeight + buttonSpacingY) * (Mathf.FloorToInt((levels.Length + columnCount - 1) / (float)columnCount)));

		for (int i=0; i<levels.Length; ++i)
		{
			int column = i % columnCount;
			int row    = (i - column) / columnCount;

			GameObject levelButton = Instantiate(buttonPrefab.gameObject) as GameObject;
			
			levelButton.transform.SetParent(transform);

			LevelButtonScript levelButtonScript = levelButton.GetComponent<LevelButtonScript>();
			levelButtonScript.audioSourceScript = audioSourceScript;
			levelButtonScript.setLevelId(i+1);

			RectTransform buttonRect    = levelButton.GetComponent<RectTransform>();
			
			buttonRect.pivot            = new Vector2(0.5f, 0.5f);
			buttonRect.anchoredPosition = new Vector2(0, 0);
			buttonRect.localPosition    = new Vector3(buttonOffsetX + buttonWidth / 2 + (buttonWidth + buttonSpacingX) * column, -buttonOffsetY - buttonHeight / 2 - (buttonHeight + buttonSpacingY) * row, 0);
			buttonRect.sizeDelta        = new Vector2(buttonWidth, buttonHeight);
			buttonRect.localScale       = new Vector3(1, 1, 1);
		}
	}
}
