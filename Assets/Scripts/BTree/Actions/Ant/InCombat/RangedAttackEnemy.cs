using UnityEngine;

public class RangedAttackEnemy : AttackEnemy
{
    [SerializeField] Transform projectileSpawn = null;
    ObjectPooler objectPooler = null;

    private void Awake()
    {
        objectPooler = ObjectPooler.GetInstance();
    }

    protected override void attack(Transform enemy)
    {
        InstantiateProjectile(enemy);
    }

    void InstantiateProjectile(Transform enemy)
    {
        Projectile projectile = objectPooler.SpawnObject("MosquitoProjectile", projectileSpawn.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.SetProjectileInfo(enemy, attackDamage);
    }
}