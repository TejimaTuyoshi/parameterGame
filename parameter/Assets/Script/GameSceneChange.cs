using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneChange : MonoBehaviour
{
    public void IngameScene()
    {
        SceneManager.LoadScene("Ingame", LoadSceneMode.Single);
    }
}
