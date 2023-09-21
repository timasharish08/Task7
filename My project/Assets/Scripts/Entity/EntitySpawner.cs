using System.Collections;
using UnityEngine;

public class EntitySpawner : EntityPool
{
    [SerializeField] private Entity[] _prefabs;

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime;

    private WaitForSeconds _spawnWait;
    private Coroutine _spawning;

    protected override void Awake()
    {
        base.Awake();
        _spawnWait = new WaitForSeconds(_spawnTime);
    }

    private void OnEnable()
    {
        _spawning = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        if (_spawning != null)
            StopCoroutine(_spawning);
    }

    private void RandomPlace(Entity gameObject)
    {
        gameObject.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }

    private IEnumerator Spawning()
    {
        Entity entity;
        if (TryGetObject(out entity))
            entity.gameObject.SetActive(true);
        else
            entity = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)]);

        RandomPlace(entity);
        yield return _spawnWait;
        _spawning = StartCoroutine(Spawning());
    }
}
