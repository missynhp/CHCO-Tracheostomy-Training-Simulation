using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using UnityEngine;
using UnityEngine.SceneManagement;
public class rTrachMan : MonoBehaviour
{
    public GameObject tVars;
    public GameObject lPanel;
    public GameObject rPanel;
    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    public int phase = 0;
    public GameObject PB4E;

    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        if (!tVars.GetComponent<tVars>().isEnt)
        {
            Debug.Log("not an ent");
            but3.SetActive(false);
        }
        else
        {
            Debug.Log("you're an ent");
        }
        // Will attach a VideoPlayer to the main camera.
        camera = GameObject.Find("Main Camera");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*

        This script manages the scenario in the scene with how the user interacts with each button, and based on the current phase,
        changes the buttons available, variables on text on screen, as well as the phase which will alter what the buttons do.
        The code itself is divided along buttons and functions which can be a little hard to understand
        so here is their breakdown by their "phase"s.

        The simulation starts on Phase 0.

        Phase 0: "By which method do you want the trach to be replaced?"
            This phase is the opening scenario for the replace trach scene. The user is presented with three options.
            by clicking:
                button1 "PICU Team": the user is sent to the "PICU Team" option which updates the display letting the user know
                that "Unable to ventilate with low pressure.", and updates the phase 21 with the choices "Stop" and "Increase Pressure"
                now available.

                button2 "PICU team before ENT team arrives": this script actually doesn't do anything, but ReplaceTrachByPICUB4ENTArrives.TaskOnPICUTeamClick() 
                is called, and a similar window to what would happen if button3 was pressed from phase 0, but with the following changes.
                - the patient expires if you "do nothing".
                - but if the user pulls on the trac ties, ReplaceTrachByPICUB4ENTArrives.TaskOnPullTrachTies() is called and success() is called.

                button 3 "ENT team": the user is then asked if "What do you want to do with the trach ties?" and updates to phase 1, with the choies
                "Do Nothing" and "Pull on trach ties" available.

        Phase 1: "What do you want to do with the trach ties?"
            This phase is the scenario when the ENT team has arrived, and the user must decide what to do with the patient's trach ties.

            button1 "Do Nothing": the patient dies, and updates to phase 23, with the choice "Try Again".

            button2 "Pull on trach ties": the patient is revived, and the user can move onto the next scenario at phase 10 with the choice "Continue".
            the text that will appear: "Success, trach replaced and patient revived. Continue to alternate scenario where patient intermittently obstructs."

        Phase 10: "Success, trach replaced and patient revived. Continue to alternate scenario where patient intermittently obstructs."
            This is a secondary shorter scenario that tests the user on what to do if there is a light obstruction.

            button1 "Continue": the phase updates to 11, with the new text, "Patient Intermittently Obstructs",
            the user is presented with three choices "Adjust neck position", "Perform flexible tracheoscopy", "Replace tube with shorter tube"

        Phase 11: "Patient Intermittently Obstructs"
            This is the alternate scenario played after the user has pulled on the trach ties and now the user is asked to check for obstructions.

            button1 "Adjust neck position": this button is disabled and the text on screen is updated to, "Failed to relieve intermitten obstruction".
            
            button2 "Perform flexible tracheoscopy": this button is disabled and the text on screne is updated to,
            "Tracheostomy tube plowed into anterior wall of the patient's trachea".

            button3 "Replace tube with shorter tube": this method is successful and success3() is called.

        Phase 21: "Unable to ventilate with low pressure."
            The animation for ventilation for an oxygen tank is shown, and it is not working, the patient needs help in a different way.

            button1 "Stop": ReplaceTrachByPICUB4ENTArrives.TaskOnPICUTeamClick() is called, and the user can try and save the patient in the same way
            as button2 from Phase 0.

            button2 "Increase Pressure": The text is updated to "Neck becomes crepitus, vitals deteriorate", and the button on the left is updated to, "CPR"
            with the phase updated to 22.

        Phase 22: "Neck becomes crepitus, vitals deteriorate."
            The patient is dying and the users only choice is to preform CPR.

            button1 "CPR": Text appears saying the patient expires and the user is asked to try again. phase is updated to 23.

        Phase 23: "Patient Expires"
            The patient has died and now the user can try again to properly complete the scenario.

            button1 "Try Again": Upon clicking this button the phase is updated to phase 0, and the scene resets to the beginning.

        Phase 3: "How do you stabilize the patient in the long term? Please select the options in the correct order."
            The patient has stablized and now the patient must be cared for in the right order.

            button1 "Get new trach": This button disappears if it was the last button clicked, success() is called.

            button2 "Insert obturator into new trach": This button disappears if it was the last button clicked, success() is called.

            button3 "Coat tip with KY jelly": As soon as this button is pressed, a success function is called, if it was the last button pressed,
            success2() is called, otherwise success() is called.

        Phase 31: "Success! Now to stabilize patient in the long term."
            The Patient has been stabalized and now the user is being asked to proceed to long term care.

            button1 "Continue": The user is then asked "How do you stabilize the patient in the long term? Please select the options in the correct order."
            with the following three options "Get new trach","Insert obturator into new trach","Coat tip with KY jelly", as phase is updated to 3.


        Phase 4: "Success! Patient stabilized. Continue to trach in place scenario."
            The user has just completed the dislodged scenario, and now is being asked to try another scenario if it is in place.

            button1 "Continue": The user will then proceed to "InspectTrach" scene. 


        In addition to these phases, there are a few other callable methods that can effect the scene.

        success(): updates phase to 31, and askes the user how to preform long term care.

        success2(): depending on if the inplace scenario is complete, the user will either be directed to it,
        or an end card will appear saying that this training is complete.

        success3(): recovery is successful with the partial obstruction scenario and is asked to move onto long term care in phase 31.

        expire(): usable to external sources and allows the creation of a try again window shown in phase 23.
    */

    public void button1()
    {
        if(phase == 0)
        {
            //here goes ambu bag fail vid
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_Fail_ambuBag.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();

            phase = 21;
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Unable to ventilate with low pressure.";
            but3.SetActive(false);

            but1.GetComponentInChildren<Text>().text = "Stop";
            but2.GetComponentInChildren<Text>().text = "Increase Pressure";
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = true;

        }
 
        else if(phase == 1)
        {
            but1.GetComponentInChildren<Text>().text = "Try again";
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
            but2.SetActive(false);
            phase = 23;
        }

        else if(phase == 10)
        {
            phase = 11;
            Debug.Log("inbutton2 phase 1");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Intermittently Obstructs";
            but2.SetActive(true);
            but3.SetActive(true);

            but1.GetComponentInChildren<Text>().text = "Adjust neck position";
            but2.GetComponentInChildren<Text>().text = "Perform flexible tracheoscopy";
            but3.GetComponentInChildren<Text>().text = "Replace tube with shorter tube";
        }

        else if (phase == 21)
        {
            phase = 0;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = false;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().TaskOnPICUTeamClick();
        }

        else if (phase == 22)
        {
            but1.GetComponentInChildren<Text>().text = "Try again";
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
            phase = 23;
        }
        else if (phase == 23)
        {
            phase = 0;
            but1.GetComponentInChildren<Text>().text = "PICU team";
            but2.GetComponentInChildren<Text>().text = "PICU team before ENT team arrives";
            but3.GetComponentInChildren<Text>().text = "ENT team";
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = false;
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "By which method do you want the trach to be replaced?";
            but1.SetActive(true);
            but2.SetActive(true);
            but3.SetActive(true);
        }
        else if (phase == 11)
        {   
            
            but1.SetActive(false);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Failed to relieve intermitten obstruction";
        }
        else if (phase == 3)
        {
            if(but2.active && but3.active)
            {
                but1.SetActive(false);
            }
            else
            {
                success();
            }
        }
        else if (phase == 31)
        {
            Debug.Log("in success");
            phase = 3;
            but1.SetActive(true);
            but2.SetActive(true);
            but3.SetActive(true);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "How do you stabilize the patient in the long term? Please select the options in the correct order.";
            but1.GetComponentInChildren<Text>().text = "Get new trach";
            but2.GetComponentInChildren<Text>().text = "Insert obturator into new trach";
            but3.GetComponentInChildren<Text>().text = "Coat tip with KY jelly";
        }
        else if (phase == 4)
        {
            SceneManager.LoadScene("Inspect Trach");
        }
        else if (phase == 5)
        {
            phase = 0;
            SceneManager.LoadScene("NewMainMenu");
        }
    }
    public void button2()
    {
        Debug.Log("inbutton2");
        if(phase == 1)
        {
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();
            Debug.Log("phase 1");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success, trach replaced and patient revived. Continue to alternate scenario where patient intermittently obstructs.";
            but1.SetActive(true);
            but2.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "Continue";
            phase = 10;

        }
        else if(phase == 21)
        {
            // VideoPlayer automatically targets the camera backplane when it is added
             // to a camera object, no need to change videoPlayer.targetCamera.
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.playOnAwake = false;
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            videoPlayer.url = "Assets/Prefabs/TeenF_crepitus.mp4";
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();

     
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Neck becomes crepitus, vitals deteriorate";
            but2.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "CPR";
            phase = 22;
        }
        else if (phase == 11)
        {
            but2.SetActive(false);
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Tracheostomy tube plowed into anterior wall of the patient's trachea";
        }
        else if (phase == 3)
        {
            if (!but1.active && but3.active)
            {
                but2.SetActive(false);
            }
            else
            {
                success();
            }
        }
    }

    public void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
    }
    public void button3()
    {
        GlobalVarStorage.RT_ENT = true;
        if (phase == 0)
        {
            Debug.Log("in here");
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "What do you want to do with the trach ties?";
            but3.SetActive(false);
            but1.GetComponentInChildren<Text>().text = "Nothing";
            but2.GetComponentInChildren<Text>().text = "Pull on trach ties";
            phase = 1;
            PB4E.GetComponent<ReplaceTrachByPICUB4ENTArrives>().otherB = true;
        }
        else if (phase == 11)
        {
            
            success3();
        }
        else if (phase == 3)
        {
            if (!but1.active && !but2.active)
            {
                but3.SetActive(false);
                success2();
            }
            else
            {
                success();
            }
        }
    }

    public void success()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        phase = 31;
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Now to stabilize patient in the long term.";
        but1.GetComponentInChildren<Text>().text = "Continue";
        but1.SetActive(true);
        but2.SetActive(false);
        but3.SetActive(false);
        //TODO: need to insert some sort of check that will let the user know that they have completed phase 3, but have done it
        //      in the wrong order and must try again.

        
    }

    public void success2()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_trachChange.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
        Debug.Log("in success2");
        phase = 4;
        if (!GlobalVarStorage.endStateSuccess)
        {
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Patient stabilized. Continue to trach in place scenario.";
            but1.GetComponentInChildren<Text>().text = "Continue";
            but1.SetActive(true);
            GlobalVarStorage.endStateSuccess = true;
        }
        else
        {
            lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Patient stabilized. Training session complete";

            but1.GetComponentInChildren<Text>().text = "Main Menu";
            but1.SetActive(true);
            phase = 5;
            GlobalVarStorage.ResetVariables();

            //TODO: could include a back to menu option somewhere here.
        }
    }

    public void success3()
    {
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Prefabs/TeenF_Success_curvedTrach.mp4";
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();

        phase = 31;
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Success! Now to stabilize patient in the long term.";
        but1.GetComponentInChildren<Text>().text = "Continue";
        but1.SetActive(true);
        but2.SetActive(false);
        but3.SetActive(false);
    }
    public void expire()
    {
        Debug.Log("in expire");
        but1.GetComponentInChildren<Text>().text = "Try again";
        but2.SetActive(false);
        but3.SetActive(false);
        lPanel.GetComponent<TMPro.TextMeshProUGUI>().text = "Patient Expired";
        phase = 23;
    }
}
