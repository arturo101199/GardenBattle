using System;
using UnityEngine;

public class Freezeable : MonoBehaviour, IFreezeable
{
    bool isFrozen = false;

    public bool IsFrozen { get => isFrozen; set => isFrozen = value; }

    public void GetFrozen()
    {
        isFrozen = true;
    }
}
