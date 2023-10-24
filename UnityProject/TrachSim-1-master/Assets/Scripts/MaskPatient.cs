using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaskPatient : MonoBehaviour
{


    /*public void TaskOnContinueClick(string choice)
    {
        if (choice == "Continue")
        {
            SceneManager.LoadScene("Patient Deteriorating");
        }
    }*/

    public void TaskOnContinueClick()
    {
        SceneManager.LoadScene("Patient Deteriorating");
    }
}
