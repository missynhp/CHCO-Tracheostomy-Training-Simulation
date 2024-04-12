using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homePageButtonManager : MonoBehaviour
{
    GameObject svars;
    // public GameObject but1;
    // public GameObject but2;
    // public GameObject but3;

    // Start is called before the first frame update
    void Start()
    {
        svars = GameObject.Find("State Vars");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void femaleIntro(string choice)
    {
        if (choice == "CPR")
        {
            Debug.Log("CPR");
            SceneManager.LoadScene("IncorrectCPRABG");
        }
        if (choice == "Inspect")
        {
            Debug.Log("Isnpect Trach");
            SceneManager.LoadScene("Inspect Trach");
        }
        if (choice == "ABG")
        {
            Debug.Log("ABG");
            SceneManager.LoadScene("IncorrectCPRABG");
        }


    }

    public void test()
    {
        Debug.Log(svars.GetComponent<stateVars>().isENT);
    }
}
