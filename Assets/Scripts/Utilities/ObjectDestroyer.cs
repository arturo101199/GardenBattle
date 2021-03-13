using UnityEngine;

public static class ObjectDestroyer
{
    static Collider[] cols = new Collider[32];

    /// <summary>
    /// The Object MUST have a collider
    /// </summary>
    /// <param name="position"></param>
    /// <param name="layerMask"></param>
    public static void DestroyObjectAtGivenPosition(Vector3 position, LayerMask layerMask)
    {
        Physics.OverlapSphereNonAlloc(position, 0.2f, cols, layerMask);
        Object.Destroy(cols[0].gameObject);
    }
}