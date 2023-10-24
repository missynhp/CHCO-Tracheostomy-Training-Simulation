using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startSim(string click)
    {
        if (click == "Continue to module start")
        {
            Debug.Log("Module started");
            SceneManager.LoadScene("Home Page");
        }
    }
}
