using UnityEngine;
using TMPro;

public class PointsWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Model _model;

    private void OnEnable()
    {
        _model.OnEatFood += OnEatFoodHandler;
    }
    private void OnDisable()
    {
        _model.OnEatFood -= OnEatFoodHandler;
    }
    private void OnEatFoodHandler()
    {
        _label.text = $"Points: {_model.Points.ToString()}";
    }
}
