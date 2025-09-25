using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer _trail;

    private Pool _pool;

    // Zenject dependency injection. //
    [Inject]
    public void Construct(Pool pool)
    {
        _pool = pool;
    }

    public void Fire(Vector3 startPos, Vector3 direction, Vector3 targetPos)
    {
        // This is purely FX. It moves the bullet with it's "tracer" to the target pos. -Shad //
        _ = MoveTowardsTargetPos(startPos, direction, targetPos);
    }

    private async Task MoveTowardsTargetPos(Vector3 startPos, Vector3 direction, Vector3 targetPos)
    {
        // Setup the bullet to start from the muzzle. -Shad //
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(direction);

        // Calculate some values. -Shad //
        float distance = Vector3.Distance(startPos, targetPos);
        float travelTime = distance / 250f;
        float elapsed = 0f;

        // Setup a timer for the actual movement. -Shad //
        while (elapsed < travelTime)
        {
            float t = elapsed / travelTime;
            transform.position = Vector3.MoveTowards(startPos, targetPos, t);
            await Task.Yield();
            elapsed += Time.deltaTime;
        }

        // After the timer while loop, this is just a safety. -Shad //
        transform.position = targetPos;

        // Wait until trail fully fades. -Shad //
        if (_trail != null) await Task.Delay((int)(_trail.time * 1000f));

        // Return bullet to the pool. -Shad //
        _pool.Despawn(this);
    }

    public class Pool : MonoMemoryPool<Bullet> { }
}
