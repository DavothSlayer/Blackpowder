using System.Collections.Generic;
using UnityEngine;

public abstract class BasePool<T> : MonoBehaviour where T : Component, IPoolable
{
    [SerializeField]
    private T _prefab;
    [SerializeField]
    private int _poolSize;

    private Queue<T> _availableObjects;

    protected virtual void Awake()
    {
        _availableObjects = new Queue<T>();
        for (int i = 0; i < _poolSize; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject()
    {
        T obj = Instantiate(_prefab, transform);
        obj.gameObject.SetActive(false);
        obj.SetPool(this);
        _availableObjects.Enqueue(obj);
        return obj;
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        T obj = _availableObjects.Dequeue();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.gameObject.SetActive(true);
        obj.OnSpawned();
        return obj;
    }

    public void Despawn(T obj)
    {
        obj.OnDespawned();
        obj.gameObject.SetActive(false);
        _availableObjects.Enqueue(obj);
    }
}

public interface IPoolable
{
    void OnSpawned();
    void OnDespawned();
    void SetPool<T>(BasePool<T> pool) where T : Component, IPoolable;
}
