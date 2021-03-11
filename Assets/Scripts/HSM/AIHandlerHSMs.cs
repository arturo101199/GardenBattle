using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIHandlerHSMs", menuName = "ScriptableObjects/AIHandlerHSMs", order = 0)]
public class AIHandlerHSMs : ScriptableObject
{
    List<HierarchicalStateMachine> machines = new List<HierarchicalStateMachine>();

    public List<HierarchicalStateMachine> Machines { get => machines;}

    public void AddMachine(HierarchicalStateMachine machine)
    {
        machines.Add(machine);
    }

    public void ClearMachines()
    {
        machines.Clear();
    }

}