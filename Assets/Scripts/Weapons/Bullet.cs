using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    private Pool _pool;

    // Zenject dependency injection. //
    [Inject]
    public void Construct(Pool pool)
    {
        _pool = pool;
    }

    public void MoveTowardsTargetPos(Vector3 startPosition, Vector3 direction, Vector3 targetPos)
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(direction);

        // Make the Task to move the bullet towards the target. //
    }

    public class Pool : MonoMemoryPool<Bullet> { }
}
