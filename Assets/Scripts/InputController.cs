using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private KeyCode _upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode _leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _rightKey = KeyCode.RightArrow;

    public Vector2Int Direction { get; private set; } = Vector2Int.up;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;
    private float _swipeThreshold = 50f;
    private Vector2Int _lastDirection = Vector2Int.up;

    void Update()
    {
        // Keyboard controls
        if (Input.GetKeyDown(_upKey) && _lastDirection != Vector2Int.down)
        {
            SetDirection(Vector2Int.up);
        }
        else if (Input.GetKeyDown(_downKey) && _lastDirection != Vector2Int.up)
        {
            SetDirection(Vector2Int.down);
        }
        else if (Input.GetKeyDown(_leftKey) && _lastDirection != Vector2Int.right)
        {
            SetDirection(Vector2Int.left);
        }
        else if (Input.GetKeyDown(_rightKey) && _lastDirection != Vector2Int.left)
        {
            SetDirection(Vector2Int.right);
        }

        // Touch controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _endTouchPosition = touch.position;
                DetectSwipe();
            }
        }
    }
    private void DetectSwipe()
    {
        Vector2 swipeVector = _endTouchPosition - _startTouchPosition;
        if (swipeVector.magnitude >= _swipeThreshold)
        {
            if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
            {
                if (swipeVector.x > 0 && _lastDirection != Vector2Int.left)
                {
                    SetDirection(Vector2Int.right);
                }
                else if (swipeVector.x < 0 && _lastDirection != Vector2Int.right)
                {
                    SetDirection(Vector2Int.left);
                }
            }
            else
            {
                if (swipeVector.y > 0 && _lastDirection != Vector2Int.down)
                {
                    SetDirection(Vector2Int.up);
                }
                else if (swipeVector.y < 0 && _lastDirection != Vector2Int.up)
                {
                    SetDirection(Vector2Int.down);
                }
            }
        }
    }
    private void SetDirection(Vector2Int newDirection)
    {
        if (newDirection != -_lastDirection) 
        {
            Direction = newDirection;
            _lastDirection = newDirection;
        }
    }
}
