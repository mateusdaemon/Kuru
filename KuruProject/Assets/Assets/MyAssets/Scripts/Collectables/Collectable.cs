using UnityEngine;

public abstract class Collectable : MonoBehaviour, ICollect
{
    public virtual void Collect()
    {
        Destroy(gameObject);
    }
}
