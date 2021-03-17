using System.Collections.Generic;
using UnityEngine;

public static class ListUtilities
{
    public static void SortFromDistanceToAnObject(List<Vector3> list, Vector3 objectPosition)
    {
        ComparerDistanceToAnObject comparer = new ComparerDistanceToAnObject(objectPosition);
        list.Sort(comparer);
    }
}