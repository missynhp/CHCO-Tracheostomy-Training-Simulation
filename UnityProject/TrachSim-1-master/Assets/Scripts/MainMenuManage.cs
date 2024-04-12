using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManage : MonoBehaviour {
    public void Press() {
        SceneManager.LoadScene("MainMenu");
    }
}
