using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadControls : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("controls", (int)Controls.Arrows );
        MovingControls.controlsKey = PlayerPrefs.GetInt("controls");
    }
}
