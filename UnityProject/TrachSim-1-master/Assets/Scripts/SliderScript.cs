using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slide;
    private void Start()
    {
        slide.value = PlayerPrefs.GetFloat("savedVol", 100);
    }


}