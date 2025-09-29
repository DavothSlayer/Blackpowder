using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;

    [SerializeField]
    private int _poolSize;

    private List<Bullet> _bulletPool;

    private void Awake() => _bulletPool = new List<Bullet>(_poolSize);

    public static void Spawn(List<Bullet> pool, Transform parent)
    {
        Bullet freeBullet = null;

        // Go through the pool. -Shad //
        for (int i = 0; i < pool.Count; i++)
        {
            // If the index is empty, jump over it. -Shad //
            if (pool[i] == null) continue;

            // Inactive object found. -Shad //
            if (!pool[i].gameObject.activeInHierarchy)
            {
                // Set the freeObject to that index, and remove it from the pool. -Shad //
                freeBullet = pool[i];
                pool.RemoveAt(i);

                freeBullet.gameObject.SetActive(true);
                break;
            }
        }
    }

    public static void Despawn(List<Bullet> pool, Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Add(bullet);
    }
}
