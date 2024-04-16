using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using System.Net.Http.Headers;
using UnityEngine.UI;
using System.Linq;
using System;


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

    public GameObject rPanel;
    public Text instructions;

    View main, board, patient, monitor, trach;
    View state;

    void InspectTrach()
    {
        View p_state = state;
        state = trach;
        animator.SetInteger("state", state.animator_ref);
        StartCoroutine(swapActivity(gameButtons[state.animator_ref], gameButtons[p_state.animator_ref]));
    }
    // int[,] substates = { { 3, 3, 1, -1 }, { 2, 2, -1, 1 }, { 1, -1, -1, -1 }, { -1, 0, 0, 0 } };  // hard-coded state values that should change, based on arrow input, and current state. ex. [left, facing trach] = [0,2] -> 1 which is face door.

    void CallACode()
    {
        GameObject codeButton = GameObject.Find("RCanvas (options)/RPanel/codeButton");
        gameButtons.Remove(gameButtonsForStart);
        foreach (List<GameObject> lbut in gameButtons)
        {
            lbut.Remove(codeButton);
        }
        codeButton.SetActive(false);
        GlobalVarStorage.CalledACode = true;
    }

    void CallAnEnt()
    {
        GameObject entButton = GameObject.Find("RCanvas (options)/RPanel/entButton");
        gameButtons.Remove(gameButtonsForStart);
        foreach (List<GameObject> lbut in gameButtons)
        {
            lbut.Remove(entButton);
        }
        entButton.SetActive(false);
        GlobalVarStorage.CalledENT = true;
    }

    void MaskPatient()
    {
        // add mask object
        UnityEngine.Object mask = Resources.Load("prefabs/mask", typeof(GameObject));
        GameObject newObject = Instantiate(mask, new Vector3(-24.13f, 12.136f, -5.791f), Quaternion.Euler(new Vector3(0, 180, 31.85f))) as GameObject;
        newObject.transform.localScale = new Vector3(7, 7, 7);
        GlobalVarStorage.PatientMasked = true;

        // change buttons
        // foreach (List<GameObject> lbut in gameButtons)
        // {
        //     lbut.Remove(maskButton);
        // }
        GameObject replaceButton = GameObject.Find("RCanvas (options)/RPanel/replaceButton");
        replaceButton.SetActive(true);
        GameObject maskButton = GameObject.Find("RCanvas (options)/RPanel/maskButton");
        maskButton.SetActive(false);
    }

    void ReplaceTrach()
    {
        GameObject replaceButton = GameObject.Find("RCanvas (options)/RPanel/replaceButton");
        replaceButton.SetActive(false);
        Text instructions = GameObject.Find("InstructionsGUI/InstructionCanvas/Panel/Text").GetComponent<Text>();
        instructions.text = "How would you like to replace the trach?";
        GameObject picuButton = GameObject.Find("RCanvas (options)/RPanel/picuButton");
        GameObject preentButton = GameObject.Find("RCanvas (options)/RPanel/preentButton");
        GameObject entTrachButton = GameObject.Find("RCanvas (options)/RPanel/entTrachButton");
        picuButton.SetActive(true);
        preentButton.SetActive(true);
        entTrachButton.SetActive(true);
    }

    void PicuTeam()
    {
        instructions.text = "Unable to ventilate with low pressure.";
        List<GameObject> oldbuttons = new List<GameObject>();
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            oldbuttons.Add(rPanel.transform.GetChild(i).gameObject);
        }
        GameObject increasePressureButton = GameObject.Find("RCanvas (options)/RPanel/increasePressureButton");
        GameObject stopButton = GameObject.Find("RCanvas (options)/RPanel/stopButton");
        List<GameObject> newButtons = new List<GameObject> { stopButton, increasePressureButton };
        StartCoroutine(swapActivity(newButtons, oldbuttons));
    }

    void PicuBeforeEnt()
    {
        Debug.Log("PICUBEFOREENT");
    }

    void EntTrach()
    {
        Debug.Log("EntTrach");
    }

    void Stop()
    {
        Debug.Log("Stop");
        instructions.text = "What do you want to do with the trach ties?";
        List<GameObject> oldbuttons = new List<GameObject>();
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            oldbuttons.Add(rPanel.transform.GetChild(i).gameObject);
        }
        GameObject nothingButton = GameObject.Find("RCanvas (options)/RPanel/nothingButton");
        GameObject pullTiesButton = GameObject.Find("RCanvas (options)/RPanel/pullTiesButton");
        List<GameObject> newButtons = new List<GameObject> { nothingButton, pullTiesButton };
        StartCoroutine(swapActivity(newButtons, oldbuttons));

    }

    void PullTies()
    {
        instructions.text = "Success, trach replaced and patient revived. Continue to alternate scenario where patient intermittently obstructs.";
        List<GameObject> oldbuttons = new List<GameObject>();
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            oldbuttons.Add(rPanel.transform.GetChild(i).gameObject);
        }
        GameObject continueButton = GameObject.Find("RCanvas (options)/RPanel/continueButton");
        StartCoroutine(swapActivity(new List<GameObject> { continueButton }, oldbuttons));
    }

    void Continue()
    {
        instructions.text = "Patient Intermittently Obstructs";
        List<GameObject> oldbuttons = new List<GameObject>();
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            oldbuttons.Add(rPanel.transform.GetChild(i).gameObject);
        }
        // "Adjust neck position", "Perform flexible tracheoscopy", "Replace tube with shorter tube"
        GameObject adjustButton = GameObject.Find("RCanvas (options)/RPanel/adjustButton");
        GameObject flexibleButton = GameObject.Find("RCanvas (options)/RPanel/flexibleButton");
        GameObject replaceWithShortButton = GameObject.Find("RCanvas (options)/RPanel/replaceWithShortButton");
        StartCoroutine(swapActivity(new List<GameObject> { adjustButton, flexibleButton, replaceWithShortButton }, oldbuttons));
    }

    void IncreasePressure()
    {
        instructions.text = "Neck becomes crepitus, vitals deteriorate";
        List<GameObject> oldbuttons = new List<GameObject>();
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            oldbuttons.Add(rPanel.transform.GetChild(i).gameObject);
        }
        GameObject cprButton = GameObject.Find("RCanvas (options)/RPanel/cprButton");
        StartCoroutine(swapActivity(new List<GameObject> { cprButton }, oldbuttons));
    }

    void AdjustNeckPosition()
    {
        instructions.text = "Failed to relieve intermitten obstruction";
        GameObject adjustButton = GameObject.Find("RCanvas (options)/RPanel/adjustButton");
        adjustButton.SetActive(false);
    }

    void FlexibleTracheostomy()
    {
        instructions.text = "Tracheostomy tube plowed into anterior wall of the patient's trachea";
        GameObject flexibleButton = GameObject.Find("RCanvas (options)/RPanel/flexibleButton");
        flexibleButton.SetActive(false);
    }

    void ReplaceWithShort()
    {
        instructions.text = "Success";
        for (int i = 0; i < rPanel.transform.childCount; i++)
        {
            rPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

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
        patient.Up = null;
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
        yield return new WaitForSeconds(0.1F);

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

        if (GlobalVarStorage.CalledACode && GlobalVarStorage.CalledENT && !GlobalVarStorage.PatientMasked)
        {
            GameObject maskButton = GameObject.Find("RCanvas (options)/RPanel/maskButton");
            gameButtonsForTrachInspect.Add(maskButton);
            maskButton.SetActive(true);
        }
    }
}
