using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextStepsRealMenu : MonoBehaviour
{

    public Animator animator;                                                              // main camera animator.
    public List<GameObject> gameButtonsForStart = new List<GameObject>();                  // list of all the buttons that need to be active when the camera pans to the start position.
    public List<GameObject> gameButtonsForTrach = new List<GameObject>();                  // list of all the buttons that need to be active when the camera pans to the trach tube position.
    public List<GameObject> gameButtonsForMonitor = new List<GameObject>();                // list of all the buttons that need to be active when the camera pans to the monitor position.
    public List<GameObject> gameButtonsForDoor = new List<GameObject>();                   // list of all the buttons that need to be active when the camera pans to the door position.
    List<List<GameObject>> gameButtons = new List<List<GameObject>>();                     // composite lists that stores the other arrays together for ease of access.
    int state = 0;                                                                         // tracks current animator state.
    int[,] substates = { {3, 3, 1, -1}, {2, 2, -1, 1}, {1 , -1, -1, -1}, {-1, 0, 0, 0} };  // hard-coded state values that should change, based on arrow input, and current state. ex. [left, facing trach] = [0,2] -> 1 which is face door.

    // Start is called before the first frame update
    void Start()
    {
        //animator is retrieved and gameButtons serves as easy access for later use by swapActivity.
        animator = GetComponent<Animator>();
        gameButtons.Add(gameButtonsForStart);
        gameButtons.Add(gameButtonsForTrach);
        gameButtons.Add(gameButtonsForMonitor);
        gameButtons.Add(gameButtonsForDoor);
    }

    // takes as input two lists of game objects that need to be activated, and game objects that need to be deactivated.
    //  the latter happens before the former.
    IEnumerator swapActivity(List<GameObject> activateList, List<GameObject> deactivateList)
    {
        yield return new WaitForSeconds(0.5F);

        for(int i = 0;  i < deactivateList.Count; i++){
            deactivateList[i].SetActive(false);
        }

        for(int i = 0;  i < activateList.Count; i++){
            activateList[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // based on key input, the animators state is updated, and the buttons that are visible are swapped.
        if (Input.GetKeyUp("left") && substates[0,state] != -1){
            int p_state = state;
            state = substates[0,state];
            animator.SetInteger("state", state);
            StartCoroutine(swapActivity(gameButtons[state], gameButtons[p_state]));
        }
        else if(Input.GetKeyUp("right") && substates[1,state] != -1){
            int p_state = state;
            state = substates[1,state];
            animator.SetInteger("state", state);
            StartCoroutine(swapActivity(gameButtons[state], gameButtons[p_state]));
        }
        else if(Input.GetKeyUp("up") && substates[2,state] != -1){
            int p_state = state;
            state = substates[2,state];
            animator.SetInteger("state", state);
            StartCoroutine(swapActivity(gameButtons[state], gameButtons[p_state]));
        }
        else if(Input.GetKeyUp("down") && substates[3,state] != -1){
            int p_state = state;
            state = substates[3,state];
            animator.SetInteger("state", state);
            StartCoroutine(swapActivity(gameButtons[state], gameButtons[p_state]));
        }
    }
}
