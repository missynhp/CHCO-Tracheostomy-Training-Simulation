using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplaceTrachByPICUB4ENTArrives : MonoBehaviour
{
    public GameObject ReplaceTrachPanel;
    public GameObject PICUTeamPanelL;
    public GameObject PICUTeamPanelR;
    public GameObject PullTrachTiesAnimation;
    public bool otherB = false;
    public GameObject rTrachMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //return to replace trach on escp click //TODO: fix
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReplaceTrachPanel.SetActive(true);
            PICUTeamPanelL.SetActive(false);
            PICUTeamPanelR.SetActive(false);
        }
    }

    //PICU before ENT arrives*****
    public void TaskOnPICUTeamClick()
    {
        if (!otherB)
        {
            if (PICUTeamPanelL.activeInHierarchy == false)
            {
                PICUTeamPanelL.SetActive(true);
                PICUTeamPanelR.SetActive(true);
            }
            ReplaceTrachPanel.SetActive(false);

        }
        GlobalVarStorage.RT_PICUb4ENT = true;
    }

    //TODO: This doesn't work
    public void TaskOnPullTrachTies()
    {
        Debug.Log("in taskonpulltrach");
        PICUTeamPanelL.SetActive(false);
        PICUTeamPanelR.SetActive(false);
        ReplaceTrachPanel.SetActive(true);
        otherB = true;
        rTrachMan.GetComponent<rTrachMan>().success();
        /*if (PICUTeamPanelL.activeInHierarchy == true)
        {
            PICUTeamPanelL.SetActive(false);
            PICUTeamPanelR.SetActive(false);
        }
        if (ReplaceTrachPanel.activeInHierarchy == true)
        {
            ReplaceTrachPanel.SetActive(false);
        }
        PullTrachTiesAnimation.SetActive(true);*/

    }

    public void PatientExpires()
    {
        if (PICUTeamPanelL.activeInHierarchy == true)
        {
            PICUTeamPanelL.SetActive(false);
            PICUTeamPanelR.SetActive(false);
        }
        if (ReplaceTrachPanel.activeInHierarchy == true)
        {
            ReplaceTrachPanel.SetActive(false);
        }
        SceneManager.LoadScene("Patient Expires");

    }

    public void expireRBP()
    {
        PICUTeamPanelL.SetActive(false);
        PICUTeamPanelR.SetActive(false);
        ReplaceTrachPanel.SetActive(true);
        otherB = true;
    }
}
