using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Videos : MonoBehaviour
{
    public VideoPlayer V_Player;


    void Update() {
        if(V_Player.isPlaying == false){
            // Wehen the player stopped playing, hide it
            V_Player.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
            
        }
    }   
}