using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ChangeHealth(-_damage);

        Die();
    }
}
