using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InspectTrachDislodgedMenu : MonoBehaviour
{
    public GameObject DislodgedChoicesPanel;
    public GameObject CallACode;
    public GameObject CallENT;
    public GameObject Meantime;

    private void Start()
    {

    }

    /*private void Update()
    {
        //return to inspect dislodged trach on escp click
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DislodgedChoicesPanel.SetActive(true);
            if (CallACode.activeInHierarchy == true)
            {
                CallACode.SetActive(false);
            }
            if (CallENT.activeInHierarchy == true)
            {
                CallENT.SetActive(false);
            }
        }
    }*/

    public void TaskOnCallACodeClick()
    {
        if(CallACode.activeInHierarchy == false)
        {
            CallACode.SetActive(true);
        }

        DislodgedChoicesPanel.SetActive(false);
        GlobalVarStorage.CalledACode = true;
    }

    public void TaskOnOKClick()
    {
        if(GlobalVarStorage.CalledACode == true && GlobalVarStorage.CalledENT == true)
        {
            Debug.Log("test1");
            WhileWaitingForArrival();
            return;
        }
        
        DislodgedChoicesPanel.SetActive(true);
        if (CallACode.activeInHierarchy == true)
        {
            CallACode.SetActive(false);
        }
        if (CallENT.activeInHierarchy == true)
        {
            CallENT.SetActive(false);
        }

    }

    public void TaskOnCallENTClick()
    {
        if(CallENT.activeInHierarchy == false)
        {
            CallENT.SetActive(true);
        }
        DislodgedChoicesPanel.SetActive(false);
        GlobalVarStorage.CalledENT = true;
    }

    private void WhileWaitingForArrival()
    {
        //Switch to "what would you like to do while we wait for the ENT and PICU/attending to arrive?"
        if (CallENT.activeInHierarchy == true)
        {
            CallENT.SetActive(false);
        }
        else
        {
            CallACode.SetActive(false);
        }

        if (Meantime.activeInHierarchy == false)
        {
            Meantime.SetActive(true);
        }

    }

    public void TaskOnMaskPatientClick()
    {
        SceneManager.LoadScene("Mask Patient");
    }
}
