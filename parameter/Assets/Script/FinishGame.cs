using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public void Finish()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�G�f�B�^�[��̂ݔ���
#else
        Application.Quit();//�r���h���ŃG�f�B�^�[�ȊO�ŋN�����Ă���Ƃ�����
#endif
    }
}
