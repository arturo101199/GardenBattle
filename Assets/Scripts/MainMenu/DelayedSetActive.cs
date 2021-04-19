using System.Collections;
using UnityEngine;

public class DelayedSetActive : MonoBehaviour
{
    public void DelaySetActive(float time)
    {
        Invoke("setActive", time);
    }

    void setActive()
    {
        gameObject.SetActive(true);
    }
}