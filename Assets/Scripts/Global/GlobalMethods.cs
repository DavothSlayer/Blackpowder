using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods : MonoBehaviour
{
    public static void Spawn(List<GameObject> pool, Transform parent)
    {
        GameObject freeObject = null;

        // Go through the pool. -Shad //
        for(int i = 0; i < pool.Count; i++) 
        {
            // If the index is empty, jump over it. -Shad //
            if (pool[i] == null) continue;
            
            // Inactive object found. -Shad //
            if (!pool[i].activeInHierarchy)
            {
                // Set the freeObject to that index, and remove it from the pool. -Shad //
                freeObject = pool[i];
                pool.RemoveAt(i);

                freeObject.SetActive(true);
                break;
            }
        }
    }

    public static void Despawn(List<GameObject> pool, GameObject gameObject)
    {
        gameObject.SetActive(false);
        pool.Add(gameObject);
    }
}
