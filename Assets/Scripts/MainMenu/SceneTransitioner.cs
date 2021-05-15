using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField] Animator panelAnim = null;
    [SerializeField] float transitionTime = 1f;
    int index = 0;

    bool isTransitioning = false;
    float timer = 0f;

    void Start()
    {
        isTransitioning = false;
        timer = 0f;
    }
    

    private void Update()
    {
        if (isTransitioning)
        {
            if(timer >= transitionTime)
            {
                SceneManager.LoadScene(index);
            }
            else
            {
                timer += Time.unscaledDeltaTime;
            }
        }
    }

    public void LoadScene(int index)
    {
        this.index = index;
        isTransitioning = true;
        panelAnim.SetTrigger("FadeOut");
    }
}