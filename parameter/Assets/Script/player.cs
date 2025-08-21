using UnityEngine;
using UnityEngine.UI;

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

    //個々の技能での成功カウント
    int _strengthCount = 0;//筋力
    int _constitutionCount = 0;//体力
    int _sizeCount = 0;//体格
    int _dexterityCount = 0;//敏捷性
    int _appearanceCount = 0;//外見
    int _intelligenceCount = 0;//知性
    int _powerCount = 0;//精神力
    int _educationCount = 0;//教育

    //計算によって出すパラメータ
    [SerializeField] int _lucky = 0;//幸運
    int _damageBonusNum = 0;//補正時の計算を基にする際の数値
    [SerializeField] int _damageBonus = 0;//攻撃時に追加される数値。
    [SerializeField] int _hp = 0;


    [SerializeField] Text statesText;//テキストにてステータスを出力

    [SerializeField] Text checkText;//テキストにて判定を出力


    void Start()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        if (player.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        _lucky = _power * 5 ;
        _damageBonusNum = _strength + _size ;
        _hp = (_constitution + _size) / 2 ;
        StatesText();
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
        DamageBonusNumber();
    }

    void MyDice(){ _myDice = _random.Next(0, 101); }

    void Success(int stateNum) //判定成功時の処理
    {
        Debug.Log($"{_myDice}:成功");
        checkText.text = ($"{_myDice}:成功!");
        if (stateNum == 1) //STR成功時
        {
            _strengthCount++;
            if (_strengthCount > 2)
            {
                _strength++;
                _strengthCount = 0;
            }
        }
        if (stateNum == 2) //CON成功時
        {
            _constitutionCount++;
            if (_constitutionCount > 2)
            {
                _constitution++;
                _constitutionCount = 0;
            }
        }
        if (stateNum == 3) //SIZ成功時
        {
            _sizeCount++;
            if (_sizeCount > 2)
            {
                _size++;
                _sizeCount = 0;
            }
        }
        if (stateNum == 4) //DEX成功時
        {
            _dexterityCount++;
            if (_dexterityCount > 2)
            {
                _dexterity++;
                _dexterityCount = 0;
            }
        }
        if (stateNum == 5) //APP成功時
        {
            _appearanceCount++;
            if (_appearanceCount > 2)
            {
                _appearance++;
                _appearanceCount = 0;
            }
        }
        if (stateNum == 6) //INT成功時
        {
            _intelligenceCount++;
            if (_intelligenceCount > 2)
            {
                _intelligence++;
                _intelligenceCount = 0;
            }
        }
        if (stateNum == 7) //POW成功時
        {
            _powerCount++;
            if (_powerCount > 2)
            {
                _power++;
                _powerCount = 0;
            }
        }
        if (stateNum == 8) //EDU成功時
        {
            _educationCount++;
            if (_educationCount > 2)
            {
                _education++;
                _educationCount = 0;
            }
        }
    }

    void Failed()//判定失敗時の処理
    {
        Debug.Log($"{_myDice}:失敗");
        checkText.text = ($"{_myDice}:失敗...");
        _hp -= 1;
    }

    void Check(int stateNum)//技能判定を行い処理をそれぞれ行う。
    {
        if(stateNum == 1) //STRの判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(1); }
            else { Failed(); }
        }
        if (stateNum == 2) //CONの判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(2); }
            else { Failed(); }
        }
        if (stateNum == 3) //SIZ判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(3); }
            else { Failed(); }
        }
        if (stateNum == 4) //DEX判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(4); }
            else { Failed(); }
        }
        if (stateNum == 5) //APP判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(5); }
            else { Failed(); }
        }
        if (stateNum == 6) //INT判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(6); }
            else { Failed(); }
        }
        if (stateNum == 7) //POW判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(7); }
            else { Failed(); }
        }
        if (stateNum == 8) //EDU判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(8); }
            else { Failed(); }
        }
    }

    public void CheckSTR() { Check(1); } //STRで判定を行う場合
    public void CheckCON() { Check(2); } //CONで判定を行う場合
    public void CheckSIZ() { Check(3); } //SIZで判定を行う場合
    public void CheckDEX() { Check(4); } //DEXで判定を行う場合
    public void CheckAPP() { Check(5); } //APPで判定を行う場合
    public void CheckINT() { Check(6); } //INTで判定を行う場合
    public void CheckPOW() { Check(7); } //POWで判定を行う場合
    public void CheckEDU() { Check(8); } //EDUで判定を行う場合

    void StatesText()
    {
        statesText.text =
     ($"STR:{_strength}\n" +
     $"CON:{_constitution}\n" +
     $"SIZE:{_size}\n" +
     $"DEX:{_dexterity}\n" +
     $"APP:{_appearance}\n" +
     $"INT:{_intelligence}\n" +
     $"POW:{_power}\n" +
     $"EDU:{_education}\n" +
     $"LUK:{_lucky}\n" +
     $"DB:{_damageBonus}\n" +
     $"HP:{_hp}");
    }

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
