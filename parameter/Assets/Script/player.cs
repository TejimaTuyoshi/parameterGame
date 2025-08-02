using UnityEngine;

public class player : MonoBehaviour
{
    System.Random _random = new System.Random();
    int _myDice = 0;//成功か失敗かを判定するための数値

    //ランダムで決めるパラメータ
    [SerializeField] int _strength = 0;//筋力
    [SerializeField] int _constitution = 0;//体力
    [SerializeField] int _size = 0;//体格
    [SerializeField] int _dexterity = 0;//敏捷性
    [SerializeField] int _appearance = 0;//外見
    [SerializeField] int _intelligence = 0;//知性
    [SerializeField] int _power = 0;//精神力
    [SerializeField] int _education = 0;//教育

    //計算によって出すパラメータ
    [SerializeField] int _lucky = 0;//幸運
    [SerializeField] int _damageBonusNum = 0;//補正時の計算を基にする際の数値
    [SerializeField] int _damageBonus = 0;//攻撃時に追加される数値。
    [SerializeField] int _hp = 0;
    void Start()
    {
        
    }

    void Update()
    {
        _lucky = _power * 5 ;
        _damageBonusNum = _strength + _size ;
        _hp = (_constitution + _size) / 2 ;
    }

    public void StartStatus()
    {
        _strength = _random.Next(03, 19);
        _constitution = _random.Next(03, 19);
        _size = _random.Next(02,07) + 6;
        _dexterity = _random.Next(03, 19);
        _appearance = _random.Next(03, 19);
        _intelligence = _random.Next(02, 07) + 6;
        _power = _random.Next(03, 19);
        _education = _random.Next(03, 19) + 6;
    }

    public void Dice(){ Debug.Log(_random.Next(01, 101)); }

    void DamageBonusNumber()//damageボーナスの補正を計算する際の関数
    {//攻撃時に毎回数値として出す予定
        if (_damageBonusNum < 13) { _damageBonus = -1 * _random.Next(01, 07); }
        else if (_damageBonusNum < 17) { _damageBonus = -1 * _random.Next(01, 05); }
        else if (_damageBonusNum < 25) { _damageBonus = 0; }
        else if (_damageBonusNum < 33) { _damageBonus = _random.Next(01, 05); }
        else if (_damageBonusNum < 40) { _damageBonus = _random.Next(01, 07); }
        else { _damageBonus = _random.Next(01, 11); }//本来はありえないがエラーを避けるために念のために作成。
    }
}
