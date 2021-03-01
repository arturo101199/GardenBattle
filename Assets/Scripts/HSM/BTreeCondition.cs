using UnityEngine;

public class BTreeCondition : Condition
{
    [SerializeField] BTree btree = null;

    public override bool EvaluateCondition()
    {
        if (btree.EvaluateTree() == NodeState.SUCCESS) return true;
        else return false;
    }
}