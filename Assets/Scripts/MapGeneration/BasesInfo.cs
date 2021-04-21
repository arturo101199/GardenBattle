using UnityEngine;

public class BasesInfo : MonoBehaviour
{
    static BasesInfo instance;
    
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
        {
            instance = this;
        }
    }

    public BaseInfo[] baseInfos;
}
