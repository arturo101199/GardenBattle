using System;
using UnityEngine;

public class EnemyNearCondition : Condition
{
    float distanceNear = 3f;
    Collider[] colsCache = new Collider[32];
    LayerMask enemyLayer = 0;
    Blackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
    }

    private void Start()
    {
        setEnemyLayer();
    }

    void setEnemyLayer()
    {
        enemyLayer = LayerMaskUtilities.getCharactersLayerExceptMyLayer(gameObject.layer);
    }

    public override bool EvaluateCondition()
    {
        int enemys = Physics.OverlapSphereNonAlloc(transform.position, distanceNear, colsCache, enemyLayer);
        if(enemys > 0)
        {
            blackboard.UpdateValue("currentEnemy", colsCache[0].transform);
            return true;
        }
        return false;
    }
}

