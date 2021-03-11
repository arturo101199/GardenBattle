using UnityEngine;

public class AIHandler : MonoBehaviour
{
    [SerializeField] AIHandlerHSMs AIHandlerHSMs = null;

    private void Start()
    {
        AIHandlerHSMs.ClearMachines();
    }

    void Update()
    {
        foreach (HierarchicalStateMachine machine in AIHandlerHSMs.Machines)
        {
            machine.UpdateMachine();
        }
    }
}