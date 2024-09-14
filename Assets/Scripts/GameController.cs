using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Model _model;
    private Ticker _ticker;
    [SerializeField] private InputControler _input;
    [SerializeField] private View _view;

    private void Start()
    {
        _model = new Model();
        var snadeHead = new Vector2Int(x:_model.FieldSize.x / 2, y: _model.FieldSize.y / 2);
        var snakeBody = snadeHead - _input.Direction;
        _model.Snake = new List<Vector2Int>
        {
            snadeHead,
            snakeBody,
            snakeBody - _input.Direction,
        };

        _model.Food = RandomNotSnake();
        _ticker = new Ticker(_model.TurnDuration, OnTickHander);

        _view.Initialize(_model);
    }


    private Vector2Int RandomNotSnake()
    {
        Vector2Int result = _model.Snake[0];

        while (IsSnake(result))
        {
            result.x = Random.Range(0, _model.FieldSize.x);
            result.y = Random.Range(0, _model.FieldSize.y);
        }
        return result;
    }

    private bool IsSnake(Vector2Int position)
    {
        return _model.Snake.Contains(position);
    }

    private void OnTickHander()
    {
        var lastSegmentPosition = _model.Snake[_model.Snake.Count - 1];
        MoveSnake(_input.Direction);

        if (IsDead())
        {
            _ticker.SetPause(true);
            new GameOver();
        }
        else {
            if (IsFoodCollected())
            {
                _model.Snake.Add(lastSegmentPosition);
                _model.Food = RandomNotSnake();
            }
        }
        _view.UpdateView();
    }

    private bool IsFoodCollected()
    {
        return _model.Snake[0] == _model.Food;
    }

    private void MoveSnake(Vector2Int direction)
    {
        for (int i = _model.Snake.Count - 1; i >= 0; --i)
        {
            if (i == 0)
            {
                _model.Snake[i] += direction;
            }
            else {
                _model.Snake[i] = _model.Snake[i - 1];
            }
        }
    }
    private bool IsDead()
    {
        var snake = _model.Snake;
        var indexOfLastSegmentOnHead = snake.FindLastIndex(segment => segment == snake[0]);
        var isSelfCollided = indexOfLastSegmentOnHead != 0;

        var isOutsideField = !IsInsideField(snake[0], _model.FieldSize);

        return isSelfCollided || isOutsideField;
    }

    private bool IsInsideField(Vector2Int position, Vector2Int fieldSize)
    {
        return position.x >= 0 &&
            position.y >= 0 &&
            position.x < fieldSize.x &&
            position.y < fieldSize.y;
    }
}
