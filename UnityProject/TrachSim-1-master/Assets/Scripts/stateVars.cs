using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateVars : MonoBehaviour {
    public bool isENT = false;
    public bool isNurse = false;
    public bool isPT = false;
    public bool isOther = false;
	
    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetState() {
        this.isENT = false;
        this.isNurse = false;
        this.isPT = false;
        this.isOther = false;
    }
}