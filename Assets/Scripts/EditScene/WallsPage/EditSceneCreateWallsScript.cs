using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditSceneCreateWallsScript : MonoBehaviour
{
	public Transform targetTransform = null;
	public Image     imagePrefab     = null;
	public int       imageHeight     = 300;



	// Use this for initialization
	void Start()
	{
		WallsImageCacheOwner.owner = this;

		for (int i=0; i<WallsImageCache.images.Count; ++i)
		{

		}
	}
}
