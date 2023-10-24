using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PicuTeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Patient Deteriorating");
        }
    }

    public void picuChoice(string choice)
    {
        if (choice == "Stop")
        {
            Debug.Log("Stop providing pressure");
            SceneManager.LoadScene("Replace Trach");
        }
        // We need to figure out what to do if testee chooses No
        if (choice == "Increase Pressure")
        {
            Debug.Log("Continue to increase pressure");
            SceneManager.LoadScene("CPR");
        }
        GlobalVarStorage.RT_PICUteam = true;
    }
}
