using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected virtual void Awake()
    {
        
    }

    protected abstract void Update();
}
