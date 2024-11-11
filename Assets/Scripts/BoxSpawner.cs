using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _boxPrefab;
    [SerializeField] private float _spawnTime;
    //[SerializeField] private float _spawnHeight;
    [SerializeField] private SpawnArea _spawnArea;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _maxPoolSize;

    private ObjectPool<Box> _pool;
    private Coroutine _spawnCoroutine; 
    
    private void Awake() 
    {
        _pool = new ObjectPool<Box>(() => Instantiate(_boxPrefab, _spawnArea.transform), 
            box => box.gameObject.SetActive(true), 
            box => box.gameObject.SetActive(false), 
            box => Destroy(box.gameObject), 
            true, _poolSize, _maxPoolSize);
    }

    private void Start() => _spawnCoroutine = StartCoroutine(Spawn());

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnTime);
        while (true)
        {
            Box box = _pool.Get();
            box.transform.position = Vector3.zero;
            
            yield return wait;
        }
    }
}