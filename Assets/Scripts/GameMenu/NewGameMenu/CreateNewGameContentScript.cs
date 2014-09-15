using UnityEngine;
using System.Collections;

public class CreateNewGameContentScript : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		Object[] levels = Resources.LoadAll("Levels");

		for (int i=0; i<levels.Length; ++i)
		{

		}
	}
}
