using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    [SerializeField] private int _health;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ChangeHealth(int number)
    {
        _health = Mathf.Clamp(_health + number, 0, int.MaxValue);
        HealthChanged?.Invoke(_health);

        if (_health == 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
