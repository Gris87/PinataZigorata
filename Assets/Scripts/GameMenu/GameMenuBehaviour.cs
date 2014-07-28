#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8)
#define TOUCH_DEVICE
#endif

using UnityEngine;
using System.Collections;

public class GameMenuBehaviour : MonoBehaviour
{
    public AudioClip clip;

#if !TOUCH_DEVICE
    void OnMouseEnter()
    {
        renderer.material.color=new Color(0.9f, 0.9f, 0.9f);
    }

    void OnMouseExit()
    {
        renderer.material.color=Color.white;
    }
#endif

    void OnMouseDown()
    {
        animation.Play("ButtonPress");

		audio.PlayOneShot(clip, 1); // TODO: Options.effectsVolume);
    }
}
