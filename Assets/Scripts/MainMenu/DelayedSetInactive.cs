using UnityEngine;

public class DelayedSetInactive : MonoBehaviour
{
    public void DelaySetInactive(float time)
    {
        Invoke("setInactive", time);
    }

    void setInactive()
    {
        gameObject.SetActive(false);
    }
}