#define SINGLETON_LIB_DEBUGGING

using UnityEngine;

public abstract class LazySingletonMonoBehaviour<T> : MonoBehaviour where T : Object
{
    // Public
    public static T Get()
    {
        if (s_Instance == null)
            s_Instance = FindObjectOfType<T>();
        return s_Instance;
    }

    // Private
    private static T s_Instance;
}

public abstract class LazySingleton<T> where T : class, new()
{
    // Public
    public static T Get()
    {
        if (s_Instance == null)
            s_Instance = new T();
        return s_Instance;
    }

    // Private
    private static T s_Instance;
}

public class Console : LazySingleton<Console>
{
    // Public
    public static void Log(string msg)
    {
        Get().LogImpl(msg);
    }

    public static void Log(string msg, LogLevel logLevel)
    {
        Get().LogImpl(msg, logLevel);
    }

    public static void LogWarning(string msg)
    {
        Get().LogWarningImpl(msg);
    }

    public static void LogError(string msg)
    {
        Get().LogErrorImpl(msg);
    }

    // Private
    private void LogImpl(string msg, LogLevel logLevel)
    {
        switch (logLevel)
        {
            case LogLevel.Normal:
                Debug.Log(msg);
                break;
            case LogLevel.Warning:
                Debug.LogWarning(msg);
                break;
            case LogLevel.Error:
                Debug.LogError(msg);
                break;
            default:
                break;
        }
    }

    private void LogImpl(string msg)
    {
        Debug.Log(msg);
    }

    private void LogWarningImpl(string msg)
    {
        Debug.LogWarning(msg);
    }

    private void LogErrorImpl(string msg)
    {
        Debug.LogError(msg);
    }
}

public enum LogLevel
{
    Normal,
    Warning,
    Error
}

public abstract class Singleton<T> where T : class
{
    public static T Get()
    {
#if SINGLETON_LIB_DEBUGGING
        if (s_Instance == null)
            Debug.LogError($"Singleton [{typeof(T).Name}] not initialized");
#endif
        return s_Instance;
    }

    protected void Init()
    {
        if (this is T inst)
        {
            s_Instance = inst;
        }
    }

    private static T s_Instance;
}

public abstract class LazySingletonScriptableObject<T> : ScriptableObject where T : class
{
    // Public
    public T Get()
    {
        if (s_Instance == null)
            s_Instance = this as T;
        return s_Instance;
    }

    // Private
    private T s_Instance;
}


public class Main
{
    void Run()
    {
        // Log.Info("Info");
        // Log.Warning("Warning");
        // Log.Error("Error");

        // Console.Log("Info");
        // Console.LogError("Error");
        // Console.Log("Error", LogType.Error);
    }
}