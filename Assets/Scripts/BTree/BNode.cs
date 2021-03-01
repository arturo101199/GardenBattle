using UnityEngine;

public abstract class BNode : MonoBehaviour, INode
{
    public abstract NodeState Evaluate();
    public abstract void OnTreeEnded();
}