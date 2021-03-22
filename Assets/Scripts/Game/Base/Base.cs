using UnityEngine;

public class Base : MonoBehaviour, IDamageable
{
    [SerializeField] float health;

    BaseManager baseManager;
    Collider[] colsCache = new Collider[1];

    LayerMask enemyLayer = 0;
    float radiusOfDetection = 4f;

    [SerializeField] bool imInDanger;
    
    private void Start()
    {
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.AddBase(this);
        enemyLayer = LayerMaskUtilities.getCharactersLayerExceptMyLayer(gameObject.layer);
    }

    private void Update()
    {
        detectEnemies();
    }

    public void GetDamage(float damageValue)
    {
        health -= damageValue;
        if(health < 0f)
        {
            baseManager.RemoveBase(this);
        }
    }

    void detectEnemies()
    {
        int n = Physics.OverlapSphereNonAlloc(transform.position, radiusOfDetection, colsCache, enemyLayer);
        if(n > 0 && !imInDanger)
        {
            AntGlobalBlackboard.Instance.UpdateValue("baseIsInDanger", true);
            imInDanger = true;
        }
        else if(n == 0 && imInDanger)
        {
            AntGlobalBlackboard.Instance.UpdateValue("baseIsInDanger", false);
            imInDanger = false;
        }
    }
}
