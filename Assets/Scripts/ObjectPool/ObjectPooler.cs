using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void OnObjectSpawn();
}

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [Header("Pool Settings")]
    public List<Pool> pools;
    public Transform poolRoot;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // 부모 오브젝트 자동 생성
        if (poolRoot == null)
        {
            GameObject root = new GameObject("ObjectPoolRoot");
            root.transform.SetParent(transform);
            poolRoot = root.transform;
        }

        // 모든 풀 초기화
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(poolRoot);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"[ObjectPooler] Pool with tag '{tag}' does not exist.");
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();

        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        if (obj.TryGetComponent<IPoolable>(out var poolable))
        {
            poolable.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(obj);

        return obj;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void CreatePool(GameObject prefab, int size, string tag_)
    {
        string tag = tag_;

        // 이미 존재하면 무시
        if (poolDictionary != null && poolDictionary.ContainsKey(tag))
            return;

        // pools 리스트에도 기록해 두면 Inspector에서도 확인 가능
        if (pools.Find(p => p.tag == tag) == null)
        {
            pools.Add(new Pool { tag = tag, prefab = prefab, size = size });
        }

        // 즉시 초기화 (Start 이후 호출될 수도 있으므로 분기)
        if (poolDictionary == null)
            return; // 아직 Start() 전이면 Start 에서 초기화됨

        Queue<GameObject> objectPool = new();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(poolRoot);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(tag, objectPool);
    }
}
