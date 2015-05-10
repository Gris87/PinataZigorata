using UnityEngine;
using System.Collections;

public class SwitchMenuScript : MonoBehaviour
{
    public GameObject previousMenu = null;
    public GameObject backButton   = null;



    public void goNext()
    {
        previousMenu.SetActive(false);
        gameObject.SetActive(true);

        backButton.SetActive(true);
    }

    public void goBack()
    {
        backButton.SetActive(false);

        gameObject.SetActive(false);
        previousMenu.SetActive(true);
    }
}
