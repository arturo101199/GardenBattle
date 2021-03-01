using UnityEngine;

[System.Serializable]
public class RandomNode
{
    [Range(0, 1)]
    public float percentage;
    public BNode node;
}