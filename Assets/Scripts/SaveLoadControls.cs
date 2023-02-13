using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveLoadControls : MonoBehaviour
{
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("controls"))
        {
            if(!MovingControls.isMobile)
            {
                PlayerPrefs.SetInt("controls", (int)Controls.Arrows);
                MovingControls.controlsKey = PlayerPrefs.GetInt("controls");
                Debug.Log("Start controls init " + (Controls)MovingControls.controlsKey);
            }
            else 
            {
                PlayerPrefs.SetInt("controls", (int)Controls.Drag);
                MovingControls.controlsKey = PlayerPrefs.GetInt("controls");
                Debug.Log("Start controls init " + (Controls)MovingControls.controlsKey);
            }
        }
        else
        {
            MovingControls.controlsKey = PlayerPrefs.GetInt("controls");
            Debug.Log("Controls loaded " + (Controls)MovingControls.controlsKey);
        }
    }

    private void Update()
    {
        if (Menu.changeControls)
        {
            PlayerPrefs.SetInt("controls", MovingControls.controlsKey);
            Debug.Log("New controls saved " + (Controls)MovingControls.controlsKey);
        }
    }
}
