using System;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour, IDamageable
{
    [Header("Debug")]
    [SerializeField] bool imInDanger;
    [SerializeField] float health;

    bool imAttacked;
    float timer = 0f;
    float timeAttacked = 4f;

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
        if (imAttacked)
        {
            if(timer >= timeAttacked)
            {
                imAttacked = false;
            }
            timer += Time.deltaTime;
        }
        else
            detectEnemies();
    }

    public void SetGlobalBlackboard(GlobalBlackboard globalBlackboard)
    {
        this.globalBlackboard = globalBlackboard;
    }

    public void GetDamage(float damageValue)
    {
        health -= damageValue;
        imAttacked = true;
        setInDanger(true);
        timer = 0f;
        if (health < 0f)
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
            setInDanger(true);
        }
        else if(n == 0 && imInDanger)
        {
            setInDanger(false);
        }
    }

    void setInDanger(bool inDanger)
    {
        globalBlackboard.UpdateValue("baseIsInDanger", inDanger);
        imInDanger = inDanger;
    }
}
