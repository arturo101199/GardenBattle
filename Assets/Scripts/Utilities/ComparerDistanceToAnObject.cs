using System.Collections.Generic;
using UnityEngine;

public class ComparerDistanceToAnObject : IComparer<Vector3>
{
    Vector3 positionToCompare;

    public ComparerDistanceToAnObject(Vector3 positionToCompare)
    {
        this.positionToCompare = positionToCompare;
    }

    public int Compare(Vector3 x, Vector3 y)
    {
        if (Vector3.SqrMagnitude(x - positionToCompare) > Vector3.SqrMagnitude(y - positionToCompare))
            return 1;
        if (Vector3.SqrMagnitude(x - positionToCompare) < Vector3.SqrMagnitude(y - positionToCompare))
            return -1;
        else
            return 0;
    }
}
