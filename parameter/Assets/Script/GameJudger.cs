using UnityEngine;

public class GameJudger : MonoBehaviour
{
    GameObject retryPanel;
    GameObject clearPanel;
      void Start()
    {
        GameObject[] Judger = GameObject.FindGameObjectsWithTag("System");
        if (Judger.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        retryPanel = GameObject.FindGameObjectWithTag("RetryPanel");
        clearPanel = GameObject.FindGameObjectWithTag("ClearPanel");
    }

      void Update()
    {

    }

    protected void Dead()
    {
        retryPanel.SetActive(true);
    }

    protected void Survive()
    {
        clearPanel.SetActive(true);
    }
}
