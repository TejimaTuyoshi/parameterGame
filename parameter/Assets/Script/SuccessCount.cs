using UnityEngine;
using UnityEngine.UI;

public class SuccessCount : MonoBehaviour
{
    [SerializeField] Text _countText;
    [SerializeField] GameObject clearPanel;
    [SerializeField] int _count = 0;
    [SerializeField] int _clearNum = 10;
    void Start()
    {
    }

    void Update()
    {
        _countText.text = $"{_count}/ {_clearNum}";
        if (_clearNum <= _count)
        {
            clearPanel.SetActive(true);
        }
    }

    public void CountUp()
    {
        _count += 1;
        Debug.Log("Nice!");
    }
}
