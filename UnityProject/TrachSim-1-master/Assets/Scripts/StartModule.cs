using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartModule : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PP;
    public GameObject PSS;
    public GameObject PosSelection;
    public GameObject Intro;
    public GameObject stateVars;
    void Start()
    {
        Intro = GameObject.Find("Intro");
        PosSelection = GameObject.Find("PosSelection");
        PSS = GameObject.Find("PatientScenarioSelection");
        PP = GameObject.Find("Patient Presented");
        stateVars = GameObject.Find("State Vars");

        PosSelection.active = false;
        PSS.active = false;
        PP.active = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startSim()
    {
        Debug.Log("Module started");
        PosSelection.active = true;
        Intro.active = false;

    }

    public void selectRole(string pos)
    {
        if (pos == "ENT")
        {
            Debug.Log("ENT selected");
            stateVars.GetComponent<stateVars>().isENT = true;
        }
        if (pos == "Nurse")
        {
            Debug.Log("Nurse selected");
            stateVars.GetComponent<stateVars>().isNurse = true;
        }
        if (pos == "PT")
        {
            Debug.Log("PT selected");
            stateVars.GetComponent<stateVars>().isPT = true;
        }
        if (pos == "Other")
        {
            Debug.Log("Other selected");
            stateVars.GetComponent<stateVars>().isOther = true;
        }

        PosSelection.active = false;
        PSS.active = true;
    }

    public void patSelect(string pat)
    {
        Debug.Log("selected " + pat);
        if (pat == "11 Year")
        {
            // PatientScenarioSelection.active = false;
            Debug.Log("11 Year old module started");
            PSS.active = false;
            PP.active = true;
        }
        if (pat == "4 month")
        {
            //PatientScenarioSelection.active = false;
            Debug.Log("4 month old module started");
            PSS.active = false;
            PP.active = true;
        }
    }

    public void patientPresented(string pp)
    {
        if (pp == "cont")
        {
            Debug.Log("1st Scene move");
            PP.active = false;
            SceneManager.LoadScene("11YearOldIntro");
        }
    }
}
