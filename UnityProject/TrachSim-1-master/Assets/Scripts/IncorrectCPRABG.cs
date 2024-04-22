using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IncorrectCPRABG : MonoBehaviour
{
    public void returnToPrevSlide(string choice)
    {
        if (choice == "ReturnToPrevSlide")
        {
            Debug.Log("Pressed");
            SceneManager.LoadScene(GlobalVarStorage.prev_scene);
        }
    }
}
