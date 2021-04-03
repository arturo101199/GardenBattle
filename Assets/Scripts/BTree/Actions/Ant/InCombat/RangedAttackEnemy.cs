using UnityEngine;

public class RangedAttackEnemy : AttackEnemy
{
    [SerializeField] GameObject projectileGO = null;
    [SerializeField] Transform projectileSpawn = null;

    protected override void attack(Transform enemy)
    {
        InstantiateProjectile(enemy);
    }

    void InstantiateProjectile(Transform enemy)
    {
        Projectile projectile = Instantiate(projectileGO, projectileSpawn.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.SetProjectileInfo(enemy, attackDamage);
    }
}