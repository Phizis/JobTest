using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool changeControls;
    public static void OnArrows()
    {
        MovingControls.controlsKey = (int)Controls.Arrows;
        changeControls =  true;
    }
public static void OnSwipe()
    {
        MovingControls.controlsKey = (int)Controls.Swipe;
        changeControls = true;
    }
    public static void OnDrag()
    {
        MovingControls.controlsKey = (int)Controls.Drag;
        changeControls = true;
    }
    public static void OnMenu()
    {
        Time.timeScale = 0f;
    }

    public static void OnResume()
    {
        Time.timeScale = 1.0f;
    }

    public static void OnExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
