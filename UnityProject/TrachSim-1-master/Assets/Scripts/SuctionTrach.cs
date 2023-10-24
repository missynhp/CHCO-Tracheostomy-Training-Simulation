using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuctionTrach : MonoBehaviour
{
    public GameObject AbleCont;
    public GameObject AbleBlank1;
    public GameObject AbleBlank2;
    public GameObject AbleBlank3;
    public GameObject AbleL;
    public GameObject AbleR;

    public GameObject UnableMask;
    public GameObject UnableIntubation;
    public GameObject UnableBlank1;
    public GameObject UnableBlank2;
    public GameObject UnableL;
    public GameObject UnableR;

    public GameObject CameraMask;
    public GameObject CameraIntubation;

    public GameObject camera;

    int count = 0;

    // Global Vars are
    // ST_Able;
    // ST_Unable;

    // Start is called before the first frame update
    void Start()
    {
        AbleBlank1.active = false;
        AbleBlank2.active = false;
        AbleBlank3.active = false;

        UnableBlank1.active = false;
        UnableBlank2.active = false;

        UnableL.active = false;
        UnableR.active = false;

        CameraIntubation.active = false;

        Debug.Log("SuctionTrach started");

        camera = GameObject.Find("Main Camera - Mask");

        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_Suction.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
    }

    public void ableContinue(string click)
    {   
        if (click == "Continue")
        {
            GlobalVarStorage.ST_Able = true;

            AbleL.active = false;
            AbleR.active = false;

            UnableL.active = true;
            UnableR.active = true;
        }
    }

    // count is used to track if the user has clicked both buttons on the unable to suction scenario before proceeding to trach replacement.
    public void unable(string click)
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/teenF_Fail_Suction.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        if (click == "Mask Patient")
        {
            count = count + 1;
            if(count == 1){
                UnableL.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Able to inflate chest.";
                UnableMask.active = false;
            }
            else if(count == 2){
                UnableL.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Able to inflate chest. Would you like to continue?";
                UnableMask.GetComponentInChildren<Text>().text = "Continue";
            }
            else{
                SceneManager.LoadScene("Patient Deteriorating");
            }
            Debug.Log("Mask Clicked");
        }

        if (click == "Intubation")
        {
            count = count + 1;
            if(count == 2){
                UnableL.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Able to intubate. Would you like to continue?";
                UnableMask.active = true;
            }
            else{
                UnableL.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Able to intubate.";
            }
            UnableIntubation.active = false;
            Debug.Log("Intubation Clicked");
        }
    }

}
