using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditSceneBackgroundScript : MonoBehaviour
{
    public Image sourceImage;
    public Image targetImage;

    public void OnImageSelected()
    {
        targetImage.sprite = sourceImage.sprite;
    }
}
