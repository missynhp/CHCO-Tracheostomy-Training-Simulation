using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplaceTrach : MonoBehaviour
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

    public void replaceTrach(string choice)
    {
        if (choice == "Yes")
        {
            Debug.Log("Yes, replace trach");
            SceneManager.LoadScene("Replace Trach");
        }
        // We need to figure out what to do if testee chooses No
        if (choice == "No")
        {
            Debug.Log("No, don't replace trach");
            SceneManager.LoadScene("IncorrectUniversal");
        }
    }
}
