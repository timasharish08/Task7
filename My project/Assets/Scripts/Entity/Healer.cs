using UnityEngine;

public class Healer : Entity
{
    [SerializeField] private int _healNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ChangeHealth(_healNumber);

        Die();
    }
}
