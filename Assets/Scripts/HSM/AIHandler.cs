using UnityEngine;

public class AIHandler : MonoBehaviour
{
    [SerializeField] HierarchicalStateMachine[] machines = null;

    void Update()
    {
        foreach (var machine in machines)
        {
            machine.UpdateMachine();
        }
    }
}