//#define IMAGE_SELECTOR_DEBUG

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ImageSelectorScript : MonoBehaviour
{
	public string pathToImages = "Images";
	public string defaultImage = "Default.jpg";

	private Button                     mLeftButton;
	private Button                     mRightButton;
	private Image                      mImage;
	private List<string>               mImages;
	private Dictionary<string, Sprite> mCachedSprites;
	private string                     mSelectedImage;
	private int                        mSelectedIndex;



	public string selectedImage
	{
		get
		{
			return mSelectedImage;
		}

		set
		{
			if (mImages.Count > 0)
			{
				mSelectedIndex = mImages.IndexOf(value);				
				StartCoroutine(startUpdateImage());
			}
		}
	}

	public int selectedIndex
	{
		get
		{
			return mSelectedIndex;
		}
		
		set
		{
			if (mImages.Count > 0)
			{
				mSelectedIndex = value;
				StartCoroutine(startUpdateImage());
			}
		}
	}



	IEnumerator startLoadingStreamingAssets()
	{
#if IMAGE_SELECTOR_DEBUG
		Debug.Log("Streaming assets path : " + Application.streamingAssetsPath);
#endif

		string listFilePath = Application.streamingAssetsPath + "/" + pathToImages + "/_list.txt";
		string[] images;

#if IMAGE_SELECTOR_DEBUG
		Debug.Log("List file path : " + listFilePath);
#endif

		if (listFilePath.Contains("://"))
		{
			// TODO: Check that _list.txt file exists
			WWW www = new WWW(listFilePath);
			yield return www;
			images = www.text.Split('\n');
		}
		else
		{
			// We don't need in list file for platforms with filesystem. So, let's remove it and get list of files with filesystem.
			// Keep list file for editor. Because it will remove it from our Assets/StreamingAssets folder
#if UNITY_EDITOR
			if (File.Exists(listFilePath))
			{
				images = File.ReadAllLines(listFilePath);
			}
			else
			{
#else		
			File.Delete(listFilePath);			
#endif
				DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath + "/" + pathToImages);
				FileInfo[] files = dir.GetFiles();
				
				images = new string[files.Length];
				
				for (int i = 0; i < files.Length; ++i)
				{
					images[i] = files[i].Name;
				}

#if UNITY_EDITOR
				Debug.Log("Please add _list.txt file with all files in Assets/StreamingAssets/" + pathToImages + " if you want to let ImageSelector work properly on Android and on Web player");
			}
#endif
		}

#if IMAGE_SELECTOR_DEBUG
		Debug.Log("List file contents :\n" + string.Join("\n", images));
#endif

		for (int i = 0; i < images.Length; ++i)
		{
			if (!images[i].Trim().Equals(""))
			{
				mImages.Add(images[i]);
			}
		}
		
#if IMAGE_SELECTOR_DEBUG
		Debug.Log(mImages.Count.ToString() + " images in Assets/StreamingAssets/" + pathToImages);
#endif
		
		if (mImages.Count > 0)
		{
			mSelectedIndex = mImages.IndexOf(defaultImage);
			StartCoroutine(startUpdateImage());
		}
		else
		{
			Debug.LogError("Images not found in Assets/StreamingAssets/" + pathToImages);
		}
	}

	IEnumerator startUpdateImage()
	{
		if (mSelectedIndex < 0)
		{
			mSelectedIndex = 0;
		}
		else
		if (mSelectedIndex > mImages.Count - 1)
		{
			mSelectedIndex = mImages.Count - 1;
		}

		mSelectedImage = mImages[mSelectedIndex];

		mLeftButton.interactable  = (mSelectedIndex > 0);
		mRightButton.interactable = (mSelectedIndex < mImages.Count - 1);

		string imagePath = Application.streamingAssetsPath + "/" + pathToImages + "/" + mSelectedImage;

#if IMAGE_SELECTOR_DEBUG
		Debug.Log("Updating image from path : " + imagePath);
#endif

		Sprite sprite = null;

		if (!mCachedSprites.TryGetValue(mSelectedImage, out sprite))
		{
			byte[] imageBytes;
			
			if (imagePath.Contains("://"))
			{
				// TODO: Cache downloaded image
				WWW www = new WWW(imagePath);
				yield return www;
				imageBytes = www.bytes;
			}
			else
			{
				imageBytes = File.ReadAllBytes(imagePath);
			}

			Texture2D texture = new Texture2D(1, 1);
			texture.LoadImage(imageBytes);
			
			sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
			mCachedSprites.Add(mSelectedImage, sprite);
		}

		mImage.sprite = sprite;
	}

	// Use this for initialization
	void Start()
	{
		mLeftButton  = transform.FindChild("LeftButton").GetComponent<Button>();
		mRightButton = transform.FindChild("RightButton").GetComponent<Button>();
		mImage       = transform.FindChild("Image").GetComponent<Image>();

		mLeftButton.onClick.AddListener(OnLeftPressed);
		mRightButton.onClick.AddListener(OnRightPressed);

		mLeftButton.interactable  = false;
		mRightButton.interactable = false;

		mImages        = new List<string>();
		mCachedSprites = new Dictionary<string, Sprite>();

		StartCoroutine(startLoadingStreamingAssets());
	}

	public void OnLeftPressed()
	{
#if IMAGE_SELECTOR_DEBUG
		Debug.Log("Left button pressed");
#endif

		--mSelectedIndex;
		StartCoroutine(startUpdateImage());
	}

	public void OnRightPressed()
	{
#if IMAGE_SELECTOR_DEBUG
		Debug.Log("Right button pressed");
#endif

		++mSelectedIndex;
		StartCoroutine(startUpdateImage());
	}
}
