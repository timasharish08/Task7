using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxYPosition;
    [SerializeField] private float _minYPosition;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void MoveUp()
    {
        ChangeTargetPosition(_stepSize);
    }

    public void MoveDown()
    {
        ChangeTargetPosition(-_stepSize);
    }

    private void ChangeTargetPosition(float number)
    {
        _targetPosition = new Vector2(_targetPosition.x, Mathf.Clamp(_targetPosition.y + number, _minYPosition, _maxYPosition));
    }
}
