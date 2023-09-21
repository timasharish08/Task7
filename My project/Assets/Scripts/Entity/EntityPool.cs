using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EntityPool : MonoBehaviour
{
    protected List<Entity> _entities;

    protected virtual void Awake()
    {
        _entities = new List<Entity>();
    }

    public Entity Instantiate(Entity prefab)
    {
        Entity entity = Instantiate(prefab, transform);
        _entities.Add(entity);

        return entity;
    }

    public bool TryGetObject(out Entity result)
    {
        result = _entities.FirstOrDefault(entity => entity.gameObject.activeSelf == false);

        return result != null;
    }
}
