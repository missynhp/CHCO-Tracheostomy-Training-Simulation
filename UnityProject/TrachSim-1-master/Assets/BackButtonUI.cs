using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonUI : MonoBehaviour
{
    //[SerializeField] private string newGameLevel = "Home - HUDTemplate";
    // Start is called before the first frame update
    public void backButtonAction()
    {
        SceneManager.LoadScene("Home - HUD Template");
    }

   
}
