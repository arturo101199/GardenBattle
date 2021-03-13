using UnityEngine;
using UnityEngine.AI;

public class AntBlackboard : Blackboard
{
    private void Awake()
    {
        initializeBlackboard();
    }

    void initializeBlackboard()
    {
        AddKeyValue("navMeshAgent", GetComponent<NavMeshAgent>());
        AddKeyValue("currentFoodLocation", Vector3.zero);
        AddKeyValue("animator", GetComponentInChildren<Animator>());
    }
}