using UnityEngine;

public interface INode
{
    NodeState Evaluate();

    void OnTreeEnded();

}