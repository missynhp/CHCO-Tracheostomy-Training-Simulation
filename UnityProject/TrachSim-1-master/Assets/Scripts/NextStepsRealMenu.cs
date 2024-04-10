using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;


public class NextStepsRealMenu : MonoBehaviour
{

    public class View
    {
        public int animator_ref;
        private View left;
        public View Left
        {
            get { return left; }
            set { left = value; }
        }

        private View right;
        public View Right
        {
            get { return right; }
            set { right = value; }
        }

        private View up;
        public View Up
        {
            get { return up; }
            set { up = value; }
        }
        private View down;
        public View Down
        {
            get { return down; }
            set { down = value; }
        }

        public View(int anim_ref)
        {
            animator_ref = anim_ref;
        }
    }
    public Animator animator;                                                              // main camera animator.
    public List<GameObject> gameButtonsForStart = new List<GameObject>();                  // list of all the buttons that need to be active when the camera pans to the start position.
    public List<GameObject> gameButtonsForTrach = new List<GameObject>();                  // list of all the buttons that need to be active when the camera pans to the trach tube position.
    public List<GameObject> gameButtonsForMonitor = new List<GameObject>();                // list of all the buttons that need to be active when the camera pans to the monitor position.
    public List<GameObject> gameButtonsForDoor = new List<GameObject>();                   // list of all the buttons that need to be active when the camera pans to the door position.
    public List<GameObject> gameButtonsForTrachInspect = new List<GameObject>();
    List<List<GameObject>> gameButtons = new List<List<GameObject>>();                     // composite lists that stores the other arrays together for ease of access.

    View main, board, patient, monitor, trach;
    View state;


    // int[,] substates = { { 3, 3, 1, -1 }, { 2, 2, -1, 1 }, { 1, -1, -1, -1 }, { -1, 0, 0, 0 } };  // hard-coded state values that should change, based on arrow input, and current state. ex. [left, facing trach] = [0,2] -> 1 which is face door.

    // Start is called before the first frame update
    void Start()
    {

        main = new View(0);
        board = new View(3);
        patient = new View(1);
        monitor = new View(2);
        trach = new View(4);

        main.Left = board;
        main.Right = monitor;
        main.Up = patient;
        main.Down = null;

        monitor.Left = patient;
        monitor.Right = null;
        monitor.Up = null;
        monitor.Down = main;

        board.Left = null;
        board.Right = main;
        board.Up = null;
        board.Down = null;

        patient.Left = board;
        patient.Right = monitor;
        patient.Up = trach;
        patient.Down = main;

        trach.Left = null;
        trach.Right = null;
        trach.Up = null;
        trach.Down = patient;

        state = main;

        //animator is retrieved and gameButtons serves as easy access for later use by swapActivity.
        animator = GetComponent<Animator>();
        gameButtons.Add(gameButtonsForStart);
        gameButtons.Add(gameButtonsForTrach);
        gameButtons.Add(gameButtonsForMonitor);
        gameButtons.Add(gameButtonsForDoor);
        gameButtons.Add(gameButtonsForTrachInspect);
        // var controller = animator.runtimeAnimatorController as AnimatorController;
        // foreach (AnimationClip clip in controller.animationClips)
        // {
        //     Debug.Log(clip);
        // }

    }

    // takes as input two lists of game objects that need to be activated, and game objects that need to be deactivated.
    //  the latter happens before the former.
    IEnumerator swapActivity(List<GameObject> activateList, List<GameObject> deactivateList)
    {
        yield return new WaitForSeconds(0.5F);

        for (int i = 0; i < deactivateList.Count; i++)
        {
            deactivateList[i].SetActive(false);
        }

        for (int i = 0; i < activateList.Count; i++)
        {
            activateList[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // based on key input, the animators state is updated, and the buttons that are visible are swapped.
        if (Input.GetKeyUp("left") && state.Left != null)
        {
            View p_state = state;
            state = state.Left;
            animator.SetInteger("state", state.animator_ref);
            StartCoroutine(swapActivity(gameButtons[state.animator_ref], gameButtons[p_state.animator_ref]));
        }
        else if (Input.GetKeyUp("right") && state.Right != null)
        {
            View p_state = state;
            state = state.Right;
            animator.SetInteger("state", state.animator_ref);
            StartCoroutine(swapActivity(gameButtons[state.animator_ref], gameButtons[p_state.animator_ref]));
        }
        else if (Input.GetKeyUp("up") && state.Up != null)
        {
            View p_state = state;
            state = state.Up;
            animator.SetInteger("state", state.animator_ref);
            StartCoroutine(swapActivity(gameButtons[state.animator_ref], gameButtons[p_state.animator_ref]));
        }
        else if (Input.GetKeyUp("down") && state.Down != null)
        {
            View p_state = state;
            state = state.Down;
            animator.SetInteger("state", state.animator_ref);
            StartCoroutine(swapActivity(gameButtons[state.animator_ref], gameButtons[p_state.animator_ref]));
        }
    }
}
