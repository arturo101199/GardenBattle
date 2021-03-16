using UnityEngine;

public class EnemyNearCondition : Condition
{
    float distanceNear = 3f;
    Collider[] colsCache = new Collider[32];
    LayerMask enemyLayer;
    Blackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
    }

    private void Start()
    {
        enemyLayer = LayerMask.GetMask("Character");
    }

    public override bool EvaluateCondition()
    {
        int enemys = Physics.OverlapSphereNonAlloc(transform.position, distanceNear, colsCache, enemyLayer);
        if(enemys > 0)
        {
            IDamageable enemy;
            for (int i = 0; i < enemys; i++)
            {
                //colsCache[]
            }
            blackboard.UpdateValue("currentEnemy",colsCache[0].GetComponent<IDamageable>());
            return true;
        }
        return false;
    }
}

