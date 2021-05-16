using UnityEngine;
using UnityEngine.AI;

public class SpiderBlackboard : Blackboard
{
    private void Awake()
    {
        initializeBlackboard();
    }

    void initializeBlackboard()
    {
        AddKeyValue("navMeshAgent", GetComponent<NavMeshAgent>());
        AddKeyValue("animator", GetComponentInChildren<Animator>());
        AddKeyValue("closerEnemyBase", Vector3.zero);
        AddKeyValue("health", 100f);
        AddKeyValue("currentEnemy", null);
        AddKeyValue("globalBlackboard", SpiderGlobalBlackboard.Instance);
        AddKeyValue("currentTrapPointLocation", Vector3.zero);
    }
}