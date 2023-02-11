using UnityEngine;

public class Menu : MonoBehaviour
{
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
