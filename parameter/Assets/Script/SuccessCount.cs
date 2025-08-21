using UnityEngine;
using UnityEngine.UI;

public class SuccessCount : MonoBehaviour
{
    [SerializeField] Text _countText;
    [SerializeField] GameObject clearPanel;
    [SerializeField] int _count;
    [SerializeField] int _clearNum = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _countText.text = $"{_count}/ {_clearNum}";
        if (_clearNum < _count)
        {
            clearPanel.SetActive(true);
        }
    }
}
