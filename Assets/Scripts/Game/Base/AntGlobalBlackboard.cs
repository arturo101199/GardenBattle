using System;
using UnityEngine;

public class AntGlobalBlackboard : Blackboard
{
    private static AntGlobalBlackboard instance;

    public static AntGlobalBlackboard Instance { get => instance; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        initializeBlackboard();
    }

    void initializeBlackboard()
    {
        AddKeyValue("resourcesEaten", 0);
        AddKeyValue("antsPatrolling", 0);
        AddKeyValue("totalNumberOfAnts", 0);
        AddKeyValue("baseIsInDanger", false);
        AddKeyValue("homeLocation", Vector3.zero);
    }
}