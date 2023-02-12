using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum Controls
{
    Arrows,
    Tap,
    Swipe
}

public class MovingControls : MonoBehaviour
{
    [Header("Player stats")] 
    [SerializeField] float lerpDuration;
    private float elapsedLerpTime;

    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] float playerStep;

    [Header("Borders")]
    [SerializeField] float borderLeft;
    [SerializeField] float borderRight;

    [Header("Touch processing")]
    [SerializeField] Canvas canvas;

    private string controlsKey = "Swipe";    

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
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > canvas.pixelRect.width / 2)
            {
                endPosition.x += playerStep * Time.deltaTime;
                endPosition.x = CheckXPosition(endPosition.x);
            }
            else
            {
                endPosition.x -= playerStep * Time.deltaTime;
                endPosition.x = CheckXPosition(endPosition.x);
            }
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

    //можно использовать такой вариант, но тогда будет не понятно, с чем именно мы работаем в этом методе +
    //т.к. отсутствуют аргументы и возвращаемые значения
    //а используя аргументы мы избавляемся от риска изменить endPosition вне нашего основного метода, +
    //в данном случае Update
    void CheckXPosition()
    {
        if (endPosition.x < borderLeft)
            endPosition.x = borderLeft;

        if (endPosition.x > borderRight)
            endPosition.x = borderRight;
    }
}
