using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteboardButton : MonoBehaviour
{

    public enum button_types
    {
        Next,
        Back,
        ENT,
        Nurse,
        PT,
        Other,
        Male,
        Female,
        Start,
        Quit
    };

    public button_types button_type;
    public int button_section;

    private GameObject stateVars;
    private GameObject section_4;
    private GameObject section_5;

    // Start is called before the first frame update
    void Start()
    {
        stateVars = GameObject.Find("State Vars");
        section_4 = GameObject.Find("Section_4");
        section_5 = GameObject.Find("Section_5");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseOver()
    {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == button_section)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == button_section)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == button_section)
        {
            if (button_type == button_types.Back)
            {
                Camera.main.GetComponent<MenuCamera>().Back();
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else 
            {
                ButtonSelection();
                Camera.main.GetComponent<MenuCamera>().Next();
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void ButtonSelection() 
    {
        switch (this.button_type)
        {
            case button_types.ENT:
                stateVars.GetComponent<stateVars>().ResetPoistions();
                stateVars.GetComponent<stateVars>().isENT = true;
                break;
            case button_types.Nurse:
                stateVars.GetComponent<stateVars>().ResetPoistions();
                stateVars.GetComponent<stateVars>().isNurse = true;
                break;
            case button_types.PT:
                stateVars.GetComponent<stateVars>().ResetPoistions();
                stateVars.GetComponent<stateVars>().isPT = true;
                break;
            case button_types.Other:
                stateVars.GetComponent<stateVars>().ResetPoistions();
                stateVars.GetComponent<stateVars>().isOther = true;
                break;
            case button_types.Male:
                this.section_5.SetActive(true);
                this.section_4.SetActive(false);
                break;
            case button_types.Female:
                this.section_5.SetActive(false);
                this.section_4.SetActive(true);
                break;
            case button_types.Start:
                SceneManager.LoadScene("11YearOldIntro");
                break;
            case button_types.Quit:
                Application.Quit();
                break;
        }
    }
}
