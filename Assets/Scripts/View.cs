using System;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private GameObject _squarePrefab;
    [SerializeField] private GameObject _snakeSegmentPrefab;
    [SerializeField] private GameObject _foodPrefab;
    [SerializeField] private Camera _camera;

    private List<GameObject> _snake = new List<GameObject>();
    private GameObject _food;
    private Model _model;

    public void Initialize(Model model)
    {
        _model = model;
        BuildField(model.FieldSize);
        SetCamera(_model.FieldSize);
        UpdateSnake(_model.Snake);

        _food = Instantiate(_foodPrefab, new Vector3(_model.Food.x, _model.Food.y, 0), Quaternion.identity);
    }
    public void UpdateView()
    {
        UpdateSnake(_model.Snake);
        _food.transform.position = new Vector3(_model.Food.x, _model.Food.y, 0);
    }

    private void UpdateSnake(List<Vector2Int> modelSnake)
    {
        Vector3 position = Vector3.zero;
        GameObject newSegment;
        for (int i = 0; i < modelSnake.Count; i++)
        {
            position.x = modelSnake[i].x;
            position.y = modelSnake[i].y;
            if (_snake.Count > i)
            {
                _snake[i].transform.position = position;
            }
            else
            {
                newSegment = Instantiate(_snakeSegmentPrefab, position, Quaternion.identity);
                _snake.Add(newSegment);
            }
        }
    }

    private void SetCamera(Vector2Int fieldSize)
    {
        // Calculate the aspect ratio of the screen
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float orthographicSize = fieldSize.y / 2f;
        float horizontalSize = fieldSize.x / 2f / screenAspect;

        _camera.orthographicSize = Mathf.Max(orthographicSize+2, horizontalSize+2);
        _camera.transform.position = new Vector3(fieldSize.x / 2.2f, fieldSize.y / 2f, -10);
        _camera.orthographic = true;
    }

    private void BuildField(Vector2Int fieldSize)
    {
        Vector3 position = Vector3.zero;
        for (int y = 0; y < fieldSize.y; y++)
        {
            for (int x = 0; x < fieldSize.x; x++)
            {
                position.y = y;
                position.x = x;
                Instantiate(_squarePrefab, position, Quaternion.identity);
            }
        }
    }
}
