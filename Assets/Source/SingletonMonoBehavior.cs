using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T>
{
    public static T Instance { get; private set; }

    protected bool SetInstance(T instance)
    {
        if (Instance == null)
        {
            Instance = instance;
            return true;
        }
        else
        {
            Destroy(this);
            return false;
        }
    }
}
