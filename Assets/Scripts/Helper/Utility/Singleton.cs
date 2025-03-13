public class Singleton<T> where T : class, new()
{
    protected static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance is null)
                instance = new T();

            return instance;
        }
    }
}