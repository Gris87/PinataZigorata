#define SETTINGS_TURN_OFF_DEBUG

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsTurnOffScript : MonoBehaviour
{
    public AudioSourceScript audioSourceScript = null;
    public Image             turnOffImage      = null;
    public string            settingsOption    = "";

    public void OnPressed()
    {
        bool isOn = turnOffImage.gameObject.activeSelf;

#if SETTINGS_TURN_OFF_DEBUG
        Debug.Log("Change " + settingsOption + " option to " + (isOn ? "true" : "false"));
#endif

        audioSourceScript.playClip();

        turnOffImage.gameObject.SetActive(!isOn);

        if (settingsOption.Equals("Sound"))
        {
            Settings.SoundEnabled = isOn;
        }
        else
        if (settingsOption.Equals("Music"))
        {
            Settings.MusicEnabled = isOn;
        }

        Settings.save();
    }

    void OnEnable()
    {
        bool isOn = true;

        if (settingsOption.Equals("Sound"))
        {
            isOn = Settings.SoundEnabled;
        }
        else
        if (settingsOption.Equals("Music"))
        {
            isOn = Settings.MusicEnabled;
        }

        turnOffImage.gameObject.SetActive(!isOn);
    }
}
