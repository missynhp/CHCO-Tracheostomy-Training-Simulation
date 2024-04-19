using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class volume : MonoBehaviour
{

    public AudioMixer audio;


    public void SetVolume(float volume){
        if(volume < 1){
            volume = .0001f;
        }
        audio.SetFloat("volume", Mathf.Log10(volume/100) * 20f);
        PlayerPrefs.SetFloat("savedVol", volume);
    }

    private void Start(){
        audio.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("savedVol", 100)/100) * 20f);
        //Debug.Log(PlayerPrefs.GetFloat("savedVol", 100f));
    }

}