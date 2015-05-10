#define EDIT_SCENE_BACK_BUTTON_DEBUG

using UnityEngine;
using System.Collections;

public class EditSceneBackButtonScript : MonoBehaviour
{
    public void OnBackPressed()
    {
#if EDIT_SCENE_BACK_BUTTON_DEBUG
        Debug.Log("Back pressed");
#endif

        Hashtable data = new Hashtable();
        data.Add(Extras.PREVIOUS_SCENE_EXTRA, Global.EDIT_SCENE_NAME);
        SceneManager.LoadScene(Global.GAME_MENU_SCENE_NAME, data);
    }
}
