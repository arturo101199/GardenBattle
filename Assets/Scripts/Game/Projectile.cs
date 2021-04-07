using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform enemy;
    float speed = 5f;
    float damage = 20f;
    ObjectPooler objectPooler = null;

    private void Awake()
    {
        objectPooler = ObjectPooler.GetInstance();
    }

    public void SetProjectileInfo(Transform enemy, float damage)
    {
        this.enemy = enemy;
        this.damage = damage;
    }

    private void Update()
    {
        updateProjectile();
    }

    void updateProjectile() //Function called on Update
    {
        if (enemy == null) //If enemy has died before projectile reaches it
            disable();
        ChaseEnemy();
    }

    void ChaseEnemy()
    {
        transform.LookAt(enemy);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == enemy) //If projectile collides with the enemy is chasing
        {
            damageEnemy();
            disable();
        }
    }

    void disable()
    {
        objectPooler.ReturnToThePool(transform);
    }

    void damageEnemy()
    {
        enemy.GetComponent<IDamageable>().GetDamage(damage);
    }

}