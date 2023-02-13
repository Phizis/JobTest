using UnityEngine;

enum Controls
{
    Arrows,
    Swipe,
    Drag
}

public class MovingControls : MonoBehaviour
{
    [Header("Player stats")] 
    [SerializeField] float lerpDuration;
    private float elapsedLerpTime;

    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] float playerStep;
    [SerializeField] float swipeStep;

    [Header("Borders")]
    [SerializeField] float borderLeft;
    [SerializeField] float borderRight;

    [Header("Touch processing")]
    [SerializeField] Canvas canvas;    

    public static int controlsKey;

    public static bool isMobile;


    void Start()
    {
        isMobile = Application.isMobilePlatform;

        startPosition = transform.position;
        endPosition = transform.position;

        SwipeDetection.SwipeEvent += SwipeMoving;
    }

    void Update()
    {
        if (Menu.changeControls)
        {
            startPosition = transform.position;
            endPosition = transform.position;
            Menu.changeControls = false;
        }

        if (controlsKey == (int)Controls.Arrows && !isMobile)
        {
            ArrowsMoving();
        }

        if (controlsKey == (int)Controls.Drag)
        {
            DragMoving();
        }

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
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            endPosition.x += playerStep * Time.deltaTime;
        }

        endPosition.x = CheckXPosition(endPosition.x);
    }

    void DragMoving()
    {
        if(!isMobile)
        {
            if (Input.GetMouseButton(0))
            {
                if(Input.mousePosition.x > canvas.pixelRect.width / 2)
                {
                    endPosition.x += playerStep * Time.deltaTime;                    
                }
                else
                {
                    endPosition.x -= playerStep * Time.deltaTime;
                }

                endPosition.x = CheckXPosition(endPosition.x);
            }
        }
        else if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > canvas.pixelRect.width / 2)
            {
                endPosition.x += playerStep * Time.deltaTime;
            }
            else
            {
                endPosition.x -= playerStep * Time.deltaTime;
            }

            endPosition.x = CheckXPosition(endPosition.x);
        }        
    }

    void SwipeMoving(Vector2 direction)
    {
        if (controlsKey == (int)Controls.Swipe)
        {
            if (direction == Vector2.right)
            {
                endPosition.x += swipeStep;
            }
            else if (direction == Vector2.left)
            {
                endPosition.x -= swipeStep;
            }
            endPosition.x = CheckXPosition(endPosition.x);
        }
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
}
