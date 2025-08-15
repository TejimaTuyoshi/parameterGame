using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public void Finish()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//エディター上のみ反応
#else
        Application.Quit();//ビルド等でエディター以外で起動しているとき反応
#endif
    }
}
