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
        AddKeyValue("closerEnemyBase", Vector3.zero);
        AddKeyValue("health", 100f);
        AddKeyValue("currentEnemy", null);
        AddKeyValue("globalBlackboard", AntGlobalBlackboard.Instance);
    }
}
