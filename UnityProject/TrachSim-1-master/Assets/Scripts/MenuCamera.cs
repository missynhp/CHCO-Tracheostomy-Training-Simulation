using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    Animator animator;
    int cam_position = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        cam_position++;
        animator.SetInteger("cam_position", cam_position);
    }

    public void Back()
    {
        cam_position--;
        animator.SetInteger("cam_position", cam_position);
    }

    public int getCamPosition() 
    {
        return this.cam_position;
    }
}
