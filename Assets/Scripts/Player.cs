using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject PlayerPosition;

    [SerializeField] float borderLeft;
    [SerializeField] float borderRight;

    void Update()
    {
        var p = transform.position;
        transform.position = CheckPositionX(p);
    }

    /// <summary>
    /// </summary>
    /// <param name="player"></param>
    /// <returns>Returns player position between -6 and 6 for X axis</returns>
    Vector3 CheckPositionX(Vector3 player)
    {
        if (player.x > 6.0f)
        {
            player.x = 6.0f;
        }
        if (player.x < -6.0f)
        {
            player.x = -6.0f;
        }

        return player;
    }

    /// <summary>
    /// Universal borders for player position
    /// </summary>
    /// <param name="player"></param>
    /// <param name="borderLeft"></param>
    /// <param name="borderRight"></param>
    /// <returns>Returns player position between two borders</returns>
    Vector3 CheckPositionX(Vector3 player, float borderLeft, float borderRight)
    {
        if (player.x > borderRight)
        {
            player.x = borderRight;
        }
        if (player.x < borderLeft)
        {
            player.x = borderLeft;
        }

        return player;
    }
}
