using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingScript : MonoBehaviour
{
    // this should be the breathing component
    SkinnedMeshRenderer breathMesh;
    // breath step size for controlling breathing animation.
    public float bc_step_size = 0.05f;
    // breath cycle pause time animation.
    public int pause_length = 1000;
    // breath position.
    float breathValue = 0f;
    // check which way to increase the count or lower it.
    bool breathIn = true;
    // pauses breath cycle to hold breath for a period of time.
    bool pauseBreath = true;
    // uses to track breath cycle.
    int pause_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        breathMesh = GetComponent<SkinnedMeshRenderer> ();
        breathValue = breathMesh.GetBlendShapeWeight (0);
        pause_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // pauses breathing in between breathing in, vs breathing out.
        if(pauseBreath){
            pause_index += 1;
            if(pause_index >= pause_length){
                pauseBreath = false;
                pause_index = 0;
            }
        }
        else{
            // increments or dicrements based on if the compoent is breathing in or not.
            if(breathIn){
                breathMesh.SetBlendShapeWeight (0, breathValue);
                breathValue += bc_step_size;
                breathIn = breathValue < 100;
                if(breathIn == false){
                    pauseBreath = true;
                }
            }
            else{
                breathMesh.SetBlendShapeWeight (0, breathValue);
                breathValue -= bc_step_size;
                breathIn = breathValue <= 0;
                if(breathIn == true){
                    pauseBreath = true;
                }
            }
        }
    }
}
