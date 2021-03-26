using UnityEngine;

public class StateSelectorOneState : StateSelector
{
    [SerializeField] State initialState = null;

    public override State SelectNode()
    {
        return initialState;
    }
}
