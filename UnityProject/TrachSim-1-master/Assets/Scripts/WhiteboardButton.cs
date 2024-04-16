using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteboardButton : MonoBehaviour {
    public enum buttonTypes {
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

    public buttonTypes buttonType;
    public int buttonSection;

	private GameObject descriptionWhiteboard;
	private GameObject stateVars;
    private GameObject femaleIntro;
    private GameObject maleIntro;

    void Start() {
		descriptionWhiteboard = GameObject.Find("DescriptionWhiteboard");
        stateVars = GameObject.Find("StateVars");
		
		maleIntro = descriptionWhiteboard.transform.Find("MaleIntro").gameObject;
        femaleIntro = descriptionWhiteboard.transform.Find("FemaleIntro").gameObject;
    }

    private void OnMouseOver() {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == buttonSection) {
            this.gameObject.transform.Find("Outline").gameObject.SetActive(true);
        }
    }

    private void OnMouseExit() {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == buttonSection) {
            this.gameObject.transform.Find("Outline").gameObject.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (Camera.main.GetComponent<MenuCamera>().getCamPosition() == buttonSection) {
            if (buttonType == buttonTypes.Back) {
                Camera.main.GetComponent<MenuCamera>().Back();
                this.gameObject.transform.Find("Outline").gameObject.SetActive(false);
            } else if (buttonType == buttonTypes.Next) {
				Camera.main.GetComponent<MenuCamera>().Next();
                this.gameObject.transform.Find("Outline").gameObject.SetActive(true);
		    } else {
                ButtonSelection();
                Camera.main.GetComponent<MenuCamera>().Next();
                this.gameObject.transform.Find("Outline").gameObject.SetActive(true);
            }
        }
    }

    private void ButtonSelection() {
        switch (this.buttonType) {
            case buttonTypes.ENT:
                stateVars.GetComponent<stateVars>().ResetState();
                stateVars.GetComponent<stateVars>().isENT = true;
                break;
            case buttonTypes.Nurse:
                stateVars.GetComponent<stateVars>().ResetState();
                stateVars.GetComponent<stateVars>().isNurse = true;
                break;
            case buttonTypes.PT:
                stateVars.GetComponent<stateVars>().ResetState();
                stateVars.GetComponent<stateVars>().isPT = true;
                break;
            case buttonTypes.Other:
                stateVars.GetComponent<stateVars>().ResetState();
                stateVars.GetComponent<stateVars>().isOther = true;
                break;
            case buttonTypes.Male:
                this.femaleIntro.SetActive(false);			    
                this.maleIntro.SetActive(true);
                break;
            case buttonTypes.Female:
                this.femaleIntro.SetActive(true);			    
                this.maleIntro.SetActive(false);
                break;
            case buttonTypes.Start:
                if (this.femaleIntro.activeSelf) {
                    SceneManager.LoadScene("11YearOldIntro");
                } else {
                    SceneManager.LoadScene("InfantIntro");
                }
                break;
            case buttonTypes.Quit:
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
                break;
        }
    }
}
