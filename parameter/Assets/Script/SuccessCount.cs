using UnityEngine;
using UnityEngine.UI;

public class SuccessCount : GameJudger
{
    [SerializeField] Text _countText;
    [SerializeField] int _count = 0;
    [SerializeField] int _clearNum = 10;
     void Start()
    {

    }

     void Update()
    {
        _countText.text = $"{_count}/ {_clearNum}";
        if (_clearNum <= _count) { Survive(); }
    }

    public void CountUp()
    {
        _count += 1;
        Debug.Log("Nice!");
    }
}
