using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InspectTrachInPlaceMenu : MonoBehaviour
{
    public GameObject InPlaceChoicesPanel;
    public GameObject IP_CallACode;
    public GameObject IP_CallENT;
    public GameObject IP_TurnOxUp;
    public GameObject IP_Meantime;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //return to inspect in place trach on escp click
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            InPlaceChoicesPanel.SetActive(true);
            if (IP_CallACode.activeInHierarchy == true)
            {
                IP_CallACode.SetActive(false);
            }
            if (IP_CallENT.activeInHierarchy == true)
            {
                IP_CallENT.SetActive(false);
            }
            if (IP_TurnOxUp.activeInHierarchy == true)
            {
                IP_TurnOxUp.SetActive(false);
            }
        }*/
    }

    public void IPTaskOnOKClick()
    {
        InPlaceChoicesPanel.SetActive(true);
        if (IP_CallACode.activeInHierarchy == true)
        {
            IP_CallACode.SetActive(false);
        }
        if (IP_CallENT.activeInHierarchy == true)
        {
            IP_CallENT.SetActive(false);
        }
        if (IP_TurnOxUp.activeInHierarchy == true)
        {
            IP_TurnOxUp.SetActive(false);
        }
    }

    public void IPTaskOnCallACodeClick()
    {
        if(IP_CallACode.activeInHierarchy == false)
        {
            IP_CallACode.SetActive(true);
        }
        InPlaceChoicesPanel.SetActive(false);
        GlobalVarStorage.IP_CalledACode = true;

        if(GlobalVarStorage.IP_CalledACode == true && GlobalVarStorage.IP_CalledENT == true && GlobalVarStorage.IP_TurnedOxUp == true)
        {
            WhileWaitingForArrival();
        }
    }

    public void IPTaskOnCallENTClick()
    {
        if(IP_CallENT.activeInHierarchy == false)
        {
            IP_CallENT.SetActive(true);
        }
        InPlaceChoicesPanel.SetActive(false);
        GlobalVarStorage.IP_CalledENT = true;

        if(GlobalVarStorage.IP_CalledACode == true && GlobalVarStorage.IP_CalledENT == true && GlobalVarStorage.IP_TurnedOxUp == true)
        {
            WhileWaitingForArrival();
        }
    }

    public void IPTaskOnTurnOxUpClick()
    {
        if(IP_TurnOxUp.activeInHierarchy == false)
        {
            IP_TurnOxUp.SetActive(true);
        }
        InPlaceChoicesPanel.SetActive(false);
        GlobalVarStorage.IP_TurnedOxUp = true;

        if(GlobalVarStorage.IP_CalledACode == true && GlobalVarStorage.IP_CalledENT == true && GlobalVarStorage.IP_TurnedOxUp == true)
        {
            WhileWaitingForArrival();
        }
    }

    private void WhileWaitingForArrival()
    {
        //Switch to "what would you like to do while we wait for the ENT and PICU/attending to arrive?"
        if (IP_TurnOxUp.activeInHierarchy == true)
        {
            IP_TurnOxUp.SetActive(false);
        }
        else if (IP_CallENT.activeInHierarchy == true)
        {
            IP_CallENT.SetActive(false);
        }
        else
        {
            IP_CallACode.SetActive(false);
        }

        if (IP_Meantime.activeInHierarchy == false)
        {
            IP_Meantime.SetActive(true);
        }
    }

    public void TaskOnSuctionTrachClick()
    {
        SceneManager.LoadScene("Suction Trach");
    }
}
