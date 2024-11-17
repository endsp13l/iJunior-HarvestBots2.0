using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private SpawnArea _spawnArea;
    [SerializeField] private Box _boxPrefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _maxPoolSize;

    private ObjectPool<Box> _pool;
    private Coroutine _spawnCoroutine;
    private bool _isActive;

    private void OnEnable() => _isActive = true;

    private void Awake()
    {
        _pool = new ObjectPool<Box>(
            createFunc: () => Instantiate(_boxPrefab),
            actionOnGet: box => box.gameObject.SetActive(true),
            actionOnRelease: box => box.gameObject.SetActive(false),
            actionOnDestroy: box => Destroy(box.gameObject),
            defaultCapacity: _poolSize,
            maxSize: _maxPoolSize
        );
    }

    private void Start() => _spawnCoroutine = StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnTime);

        while (_isActive)
        {
            Box box = _pool.Get();
            box.transform.position = _spawnArea.GetRandomPosition();

            yield return wait;
        }
    }

    private void OnDisable()
    {
        _isActive = false;

        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }
}