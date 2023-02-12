using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingControls : MonoBehaviour
{
    [SerializeField] float lerpDuration;
    private float elapsedLerpTime;

    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] float playerStep;

    [SerializeField] float borderLeft;
    [SerializeField] float borderRight;

    private string controlsKey = "Arrows";

    //we can use GameObject Player if necessary instead transform position
    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position;
    }

    void Update()
    {
        if (controlsKey == "Arrows")
        {
            ArrowsMoving();
        }
        if (controlsKey == "Tap")
            TapMoving();

        if(controlsKey == "Swipe")
            SwipeMoving();

        if (transform.position != endPosition) 
        {
            elapsedLerpTime += Time.deltaTime;
            float percentageComplete = elapsedLerpTime / lerpDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);            
        }
        else
        {
            elapsedLerpTime = 0;
            startPosition = transform.position;
        }
    }

    void ArrowsMoving()
    {        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            endPosition.x -= playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            endPosition.x += playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }
    }

    void TapMoving()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            endPosition.x -= playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            endPosition.x += playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }
    }

    void SwipeMoving()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            endPosition.x -= playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            endPosition.x += playerStep * Time.deltaTime;
            endPosition.x = CheckXPosition(endPosition.x);
        }
    }

    float Lerping(float elapsedLerpTime, float lerpSpeed)
    {
        elapsedLerpTime += Time.deltaTime;
        float percentageComplete = elapsedLerpTime / lerpSpeed;

        return percentageComplete;
    }

    /// <summary>
    /// Method takes x-coordinate to check if Object is out of bounds
    /// </summary>
    /// <param name="xEndPosition"></param>
    /// <returns>Returns correct x-coordinate</returns>
    float CheckXPosition(float xEndPosition)
    {
        if (xEndPosition < borderLeft)
            xEndPosition = borderLeft;

        if (xEndPosition > borderRight)
            xEndPosition = borderRight;

        return xEndPosition;
    }

    //����� ������������ ����� �������, �� ����� ����� �� �������, � ��� ������ �� �������� � ���� ������ +
    //�.�. ����������� ��������� � ������������ ��������
    //� ��������� ��������� �� ����������� �� ����� �������� endPosition ��� ������ ��������� ������, +
    //� ������ ������ Update
    void CheckXPosition()
    {
        if (endPosition.x < borderLeft)
            endPosition.x = borderLeft;

        if (endPosition.x > borderRight)
            endPosition.x = borderRight;
    }
}
