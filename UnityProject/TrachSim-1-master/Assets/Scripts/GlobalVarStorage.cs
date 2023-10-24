using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVarStorage : MonoBehaviour
{
    // Defining global vars
    public static int iter;

    //Defining global vars for InspectTrachDislodgedMenu
    public static bool CalledACode;
    public static bool CalledENT;

    //Defining global vars for InspectTrachInPlaceMenu
    public static bool IP_CalledACode;
    public static bool IP_CalledENT;
    public static bool IP_TurnedOxUp;

    //Defining global vars for SuctionTrach
    public static bool ST_Able;
    public static bool ST_Unable;

    // Creating global bools to ensure learner has gone through all 3 replace trach scenarios before being shown the in-place inspect trach
    public static bool RT_PICUteam;
    public static bool RT_PICUb4ENT;
    public static bool RT_ENT;
    public static bool endStateSuccess;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize global bools
        if (iter == 0)
        {

            ResetVariables();

            iter++;
        }
        else{
            Destroy(this.gameObject);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ResetVariables() 
    {
        //For dislodged branch
        CalledACode = false;
        CalledENT = false;

        // For in place branch
        IP_CalledACode = false;
        IP_CalledENT = false;
        IP_TurnedOxUp = false;

        // For suction trach
        ST_Able = false;
        ST_Unable = false;

        //Disloged to in place check bools
        RT_ENT = false;
        RT_PICUb4ENT = false;
        RT_PICUteam = false;
        endStateSuccess = false;
    }
}
