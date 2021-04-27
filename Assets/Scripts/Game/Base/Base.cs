using System;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour, IDamageable
{
    [Header("Debug")]
    [SerializeField] bool imInDanger;

    [SerializeField] float health;

    BaseManager baseManager;
    Collider[] colsCache = new Collider[1];

    LayerMask enemyLayer = 0;
    float radiusOfDetection = 4f;

    GlobalBlackboard globalBlackboard = null;
    List<IDamageable> characters = new List<IDamageable>();

    private void Awake()
    {
        baseManager = FindObjectOfType<BaseManager>();
        baseManager.AddBase(this);
    }

    private void Start()
    {

        enemyLayer = LayerMaskUtilities.GetCharactersLayerExceptMyLayer(gameObject.layer);
    }

    private void Update()
    {
        detectEnemies();
    }

    public void SetGlobalBlackboard(GlobalBlackboard globalBlackboard)
    {
        this.globalBlackboard = globalBlackboard;
    }

    public void GetDamage(float damageValue)
    {
        health -= damageValue;
        if(health < 0f)
        {
            killCharacters();
            baseManager.RemoveBase(this);
            Destroy(this.gameObject);
        }
    }

    private void killCharacters()
    {
        foreach (IDamageable character in characters)
        {
            character.GetDamage(1000f);
        }
    }

    public void AddCharacter(IDamageable character)
    {
        characters.Add(character);
    }
    
    public void RemoveCharacter(IDamageable character)
    {
        characters.Remove(character);
    }

    void detectEnemies()
    {
        int n = Physics.OverlapSphereNonAlloc(transform.position, radiusOfDetection, colsCache, enemyLayer);
        if(n > 0 && !imInDanger)
        {
            globalBlackboard.UpdateValue("baseIsInDanger", true);
            imInDanger = true;
        }
        else if(n == 0 && imInDanger)
        {
            globalBlackboard.UpdateValue("baseIsInDanger", false);
            imInDanger = false;
        }
    }
}
