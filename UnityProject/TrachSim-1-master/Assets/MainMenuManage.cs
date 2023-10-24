using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Press()
    {
        SceneManager.LoadScene("NewMainMenu");
    }

    // Update is called once per fram
}
