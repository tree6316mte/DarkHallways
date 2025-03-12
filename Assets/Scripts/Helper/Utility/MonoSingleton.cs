using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    public static T Instance => instance;
    [SerializeField] protected bool isDontDestroyOnLoad = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning($"Singleton \"{this.GetType()}\" is Duplicated : {this.name}");
            DestroyImmediate(this.gameObject);
        }
        else
        {
            instance = this.gameObject.GetComponent<T>();
            if (isDontDestroyOnLoad) DontDestroyOnLoad(instance);
        }
    }

    private void OnDestroy()
    {
        if (instance != null && instance == this)
            instance = null;
    }
}
