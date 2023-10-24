using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreteenScenarioController : MonoBehaviour
{
    // Creating local GameObjects to display in place/dislodged panels
    public GameObject InPlaceChoicesPanel;
    public GameObject DislodgedChoicesPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(GlobalVarStorage.endStateSuccess == true)
        {
            DislodgedChoicesPanel.SetActive(false);
            InPlaceChoicesPanel.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
