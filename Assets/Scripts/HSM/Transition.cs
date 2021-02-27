using UnityEngine;

[System.Serializable]
public class Transition
{
    [SerializeField] State targetNode;

    public State TargetNode { get => targetNode; }

    public bool isTriggered()
    {
        return false;
    }
}