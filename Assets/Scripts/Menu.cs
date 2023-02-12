using UnityEngine;

public class Menu : MonoBehaviour
{
    public static void OnArrows()
    {
        MovingControls.controlsKey = (int)Controls.Arrows;
    }
    public static void OnSwipe()
    {
        MovingControls.controlsKey = (int)Controls.Swipe;
    }
    public static void OnDrag()
    {
        MovingControls.controlsKey = (int)Controls.Drag;
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
