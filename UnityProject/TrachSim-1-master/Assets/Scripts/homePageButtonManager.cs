using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class homePageButtonManager : MonoBehaviour
{
    GameObject svars;
    GameObject camera;

    GameObject sound_slider;

    GameObject sound_button;
    // public GameObject but1;
    // public GameObject but2;
    // public GameObject but3;

    // Start is called before the first frame update
    void Start()
    {
        svars = GameObject.Find("State Vars");
        camera = GameObject.Find("Main Camera");
        sound_slider = GameObject.Find("RCanvas (options)/RPanel/Sound Slider");
        sound_button = GameObject.Find("RCanvas (options)/RPanel/SoundSetting");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void babyintro(string choice)
    {
        if (choice == "SoundToggle")
        {
            sound_button.SetActive(false);
            sound_slider.SetActive(true);
        }
        else
        {
            sound_button.SetActive(true);
            sound_slider.SetActive(false);
        }
        if (choice == "CPR")
        {
            GlobalVarStorage.CalledACode = false;
            GlobalVarStorage.CalledENT = false;
            GlobalVarStorage.PatientMasked = false;
            GlobalVarStorage.prev_scene = "InfantIntro";
            SceneManager.LoadScene("IncorrectCPRABG");
        }
        if (choice == "Inspect")
        {
            camera.SendMessage("InspectTrach");
            // SceneManager.LoadScene("Inspect Trach");
        }
        if (choice == "ABG")
        {
            GlobalVarStorage.CalledACode = false;
            GlobalVarStorage.CalledENT = false;
            GlobalVarStorage.PatientMasked = false;
            GlobalVarStorage.prev_scene = "InfantIntro";
            SceneManager.LoadScene("IncorrectCPRABG");
        }
        if (choice == "CallACode")
        {
            camera.SendMessage("CallACode");
        }
        if (choice == "CallAnEnt")
        {
            camera.SendMessage("CallAnEnt");
        }
        if (choice == "MaskPatient")
        {
            camera.SendMessage("MaskPatient", "infant");
        }
        if (choice == "ReplaceTrach")
        {
            camera.SendMessage("ReplaceTrach");
        }
        if (choice == "PicuTeam")
        {
            camera.SendMessage("PicuTeam");
        }
        if (choice == "PicuBeforeEnt")
        {
            camera.SendMessage("PicuBeforeEnt");
        }
        if (choice == "EntTrach")
        {
            camera.SendMessage("EntTrach");
        }
        if (choice == "Stop")
        {
            camera.SendMessage("Stop");
        }
        if (choice == "Nothing")
        {
            GlobalVarStorage.prev_scene = "InfantIntro";
            SceneManager.LoadScene("IncorrectCPRABG");
        }
        if (choice == "PullTies")
        {
            camera.SendMessage("PullTies");
        }
        if (choice == "Continue")
        {
            camera.SendMessage("Continue");
        }
        if (choice == "IncreasePressure")
        {
            camera.SendMessage("IncreasePressure");
        }
        if (choice == "AdjustNeckPosition")
        {
            camera.SendMessage("AdjustNeckPosition");
        }
        if (choice == "FlexibleTracheostomy")
        {
            camera.SendMessage("FlexibleTracheostomy");
        }
        if (choice == "ReplaceWithShort")
        {
            camera.SendMessage("ReplaceWithShort");
        }

    }



    public void femaleIntro(string choice)
    {
        if (choice == "SoundToggle")
        {
            sound_button.SetActive(false);
            sound_slider.SetActive(true);
        }
        else
        {
            sound_button.SetActive(true);
            sound_slider.SetActive(false);
        }
        if (choice == "CPR")
        {
            GlobalVarStorage.CalledACode = false;
            GlobalVarStorage.CalledENT = false;
            GlobalVarStorage.PatientMasked = false;
            GlobalVarStorage.prev_scene = "11YearOldIntro";
            SceneManager.LoadScene("IncorrectCPRABG");
            SceneManager.UnloadSceneAsync("11YearOldIntro");
        }
        if (choice == "Inspect")
        {
            camera.SendMessage("InspectTrach");
            // SceneManager.LoadScene("Inspect Trach");
        }
        if (choice == "ABG")
        {
            GlobalVarStorage.CalledACode = false;
            GlobalVarStorage.CalledENT = false;
            GlobalVarStorage.PatientMasked = false;
            GlobalVarStorage.prev_scene = "11YearOldIntro";
            SceneManager.LoadScene("IncorrectCPRABG");
        }
        if (choice == "CallACode")
        {
            camera.SendMessage("CallACode");
        }
        if (choice == "CallAnEnt")
        {
            camera.SendMessage("CallAnEnt");
        }
        if (choice == "MaskPatient")
        {
            camera.SendMessage("MaskPatient", "11");
        }
        if (choice == "ReplaceTrach")
        {
            camera.SendMessage("ReplaceTrach");
        }
        if (choice == "PicuTeam")
        {
            camera.SendMessage("PicuTeam");
        }
        if (choice == "PicuBeforeEnt")
        {
            camera.SendMessage("PicuBeforeEnt");
        }
        if (choice == "EntTrach")
        {
            camera.SendMessage("EntTrach");
        }
        if (choice == "Stop")
        {
            camera.SendMessage("Stop");
        }
        if (choice == "Nothing")
        {
            SceneManager.LoadScene("IncorrectCPRABG");
            GlobalVarStorage.prev_scene = "11YearOldIntro";
        }
        if (choice == "PullTies")
        {
            camera.SendMessage("PullTies");
        }
        if (choice == "Continue")
        {
            camera.SendMessage("Continue");
        }
        if (choice == "IncreasePressure")
        {
            camera.SendMessage("IncreasePressure");
        }
        if (choice == "AdjustNeckPosition")
        {
            camera.SendMessage("AdjustNeckPosition");
        }
        if (choice == "FlexibleTracheostomy")
        {
            camera.SendMessage("FlexibleTracheostomy");
        }
        if (choice == "ReplaceWithShort")
        {
            camera.SendMessage("ReplaceWithShort");
        }

    }

    public void test()
    {
        Debug.Log(svars.GetComponent<stateVars>().isENT);
    }
}
