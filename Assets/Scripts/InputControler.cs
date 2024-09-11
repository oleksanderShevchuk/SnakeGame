using UnityEngine;

public class InputControler : MonoBehaviour
{
    [SerializeField] private KeyCode _upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode _leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _rightKey = KeyCode.RightArrow;

    public Vector2Int Direction { get; private set; } = Vector2Int.up;

    void Update()
    {
        // Keyboard controls
        if (Input.GetKeyDown(_upKey))
        {
            Direction = Vector2Int.up;
        }
        else if (Input.GetKeyDown(_downKey))
        {
            Direction = Vector2Int.down;
        }
        else if (Input.GetKeyDown(_leftKey))
        {
            Direction = Vector2Int.left;
        }
        else if (Input.GetKeyDown(_rightKey))
        {
            Direction = Vector2Int.right;
        }

        //// Mouse (and touch) controls
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 position = Input.mousePosition;
        //    if (position.x < Screen.width / 2)
        //    {
        //        if (lastDirection == Vector2Int.up)
        //        {
        //            Direction = Vector2Int.left;
        //        }
        //        else if (lastDirection == Vector2Int.down)
        //        {
        //            Direction = Vector2Int.right;
        //        }
        //        else if (lastDirection == Vector2Int.left)
        //        {   
        //            Direction = Vector2Int.down;
        //        }
        //        else if (lastDirection == Vector2Int.right)
        //        {
        //            Direction = Vector2Int.up;
        //        }
        //    }
        //    else
        //    {
        //        if (lastDirection == Vector2Int.up)
        //        {
        //            Direction = Vector2Int.right;
        //        }
        //        else if (lastDirection == Vector2Int.down)
        //        {
        //            Direction = Vector2Int.left;
        //        }
        //        else if (lastDirection == Vector2Int.left)
        //        {
        //            Direction = Vector2Int.up;
        //        }
        //        else if (lastDirection == Vector2Int.right)
        //        {
        //            Direction = Vector2Int.down;
        //        }
        //    }
        //}
    }
}
