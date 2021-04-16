using UnityEngine;

public class Freeze : MonoBehaviour
{
    LayerMask enemiesMask;
    Collider[] colsCache = new Collider[32];
    ObjectPooler objectPooler;
    [SerializeField] float freezeRange = 1.5f;

    private void Start()
    {
        objectPooler = ObjectPooler.GetInstance();
        enemiesMask = LayerMaskUtilities.GetCharactersLayerExceptMyLayer(LayerMask.NameToLayer("Spider"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(LayerMaskUtilities.MaskContainsLayer(enemiesMask, other.gameObject.layer))
        {
            int enemies = Physics.OverlapSphereNonAlloc(transform.position, freezeRange, colsCache, enemiesMask);
            for (int i = 0; i < enemies; i++)
            {
                colsCache[i].GetComponent<IFreezeable>().GetFrozen();
            }
            objectPooler.ReturnToThePool(transform);
        }
    }
}