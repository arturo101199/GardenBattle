using UnityEngine;

public class GlobalBlackboard : Blackboard
{
    protected static GlobalBlackboard instance;

    public static GlobalBlackboard Instance { get => instance; }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
        initializeBlackboard();
    }

    protected virtual void initializeBlackboard()
    {
        AddKeyValue("totalNumberOfCharacters", 25);
    }
}
