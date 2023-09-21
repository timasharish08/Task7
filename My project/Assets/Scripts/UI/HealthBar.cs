using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heart _prefab;
    [SerializeField] private Player _player;

    private List<Heart> _hearts;

    private void Awake()
    {
        _hearts = new List<Heart>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnPlayerHealthChange;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnPlayerHealthChange;
    }

    public void OnPlayerHealthChange(int health)
    {
        for (int i = _hearts.Count; i < health; i++)
            CreateHeart();

        for (int i = _hearts.Count; i > health; i--)
            DestroyHeart();
    }

    public void CreateHeart()
    {
        Heart heart = Instantiate(_prefab, transform);
        _hearts.Add(heart);
        heart.ToFill();
    }

    public void DestroyHeart()
    {
        Heart heart = _hearts[_hearts.Count - 1];
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
