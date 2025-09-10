using UnityEngine;
using UnityEngine.UI;

public class player : GameJudger
{
    System.Random _random = new System.Random();
    int _myDice = 0;//成功か失敗かを判定するための数値
    //ランダムで決めるパラメータ
    int _strength = 0;//筋力
    int _constitution = 0;//体力
    int _size = 0;//体格
    int _dexterity = 0;//敏捷性
    int _appearance = 0;//外見
    int _intelligence = 0;//知性
    int _power = 0;//精神力
    int _education = 0;//教育

    //計算によって出すパラメータ
    int _lucky = 0;//幸運
    int _damageBonusNum = 0;//補正時の計算を基にする際の数値
    int _damageBonus = 0;//攻撃時に追加される数値。
    [SerializeField] int _hp = 0;
    [SerializeField] int _mp = 0;
    [SerializeField] int _sanity = 0;
    int _maxHp = 0;
    int _maxMp = 0;
    int _maxSanity = 0;

    [SerializeField] Text statesText;//テキストにてステータスを出力
    [SerializeField] Text moveStatesText;

    [SerializeField] Text checkText;//テキストにて判定を出力

    [SerializeField] SuccessCount successCount;
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

        if (_hp == 0) { Dead(); }

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

        _lucky = _power * 5;
        _damageBonusNum = _strength + _size;
        _maxHp = (_constitution + _size) / 2;
        _maxMp = _power;
        _maxSanity = _power * 5;
        _hp = _maxHp;
        _mp = _maxMp;
        _sanity = _maxSanity;

        DamageBonusNumber();
    }

    void MyDice(){ _myDice = _random.Next(0, 101); }

    void Success(int stateNum) //判定成功時の処理
    {
        Debug.Log($"{_myDice}:成功");
        checkText.text = ($"{_myDice}:成功!");
        successCount.CountUp();

        if (stateNum == 0 && _hp <= (_constitution + _size) / 2)
        {
            MyDice();
            if (_myDice <= _dexterity + _intelligence)
            {
                Debug.Log("回復成功");
                _hp++;
            }
            else { Debug.Log("回復失敗"); }
        }
         else if (stateNum == 1) //STR大成功時
        {
            Debug.Log("STR増加成功");
            _sanity++;
            _strength++;
        }
        else if (stateNum == 2) //CON大成功時
        {
            Debug.Log("CON増加成功");
            _sanity++;
            _constitution++;
        }
        else if (stateNum == 3) //SIZ大成功時
        {
            Debug.Log("SIZ増加成功");
            _sanity++;
            _size++;
        }
        else if (stateNum == 4) //DEX大成功時
        {
            Debug.Log("DEX増加成功");
            _sanity++;
            _dexterity++;
        }
        else if (stateNum == 5) //APP大成功時
        {
            Debug.Log("APP増加成功");
            _sanity++;
            _appearance++;
        }
        else if (stateNum == 6) //INT大成功時
        {
            Debug.Log("INT増加成功");
            _sanity++;
            _intelligence++;
        }
        else if (stateNum == 7) //POW大成功時
        {
            Debug.Log("POW増加成功");
            _sanity++;
            _power++;
        }
        else if (stateNum == 8) //EDU大成功時
        {
            Debug.Log("EDU増加成功");
            _sanity++;
            _education++;
        }
        StatesCheck();
    }

    void Failed(int stateNum)//判定失敗時の処理
    {
        Debug.Log($"{_myDice}:失敗");
        checkText.text = ($"{_myDice}:失敗...");

        if (stateNum == 0)//通常失敗
        {
            _hp--;
        }
        else if (stateNum == 1)//STR大失敗
        {
            Debug.Log("STRペナルティ...");
            _hp--;
            _sanity--;
            _strength -= 1;
        }
        else if (stateNum == 2)//CON大失敗
        {
            Debug.Log("CONペナルティ...");
            _hp--;
            _sanity--;
            _constitution -= 1;
        }
        else if (stateNum == 3)//SIZ大失敗
        {
            Debug.Log("SIZペナルティ...");
            _hp--;
            _sanity--;
            _size -= 1;
        }
        else if (stateNum == 4)//DEX大失敗
        {
            Debug.Log("DEXペナルティ...");
            _hp--;
            _sanity--;
            _dexterity -= 1;
        }
        else if (stateNum == 5)//APP大失敗
        {
            Debug.Log("APPペナルティ...");
            _hp--;
            _sanity--;
            _appearance -= 1;
        }
        else if (stateNum == 6)//INT大失敗
        {
            Debug.Log("INTペナルティ...");
            _hp--;
            _sanity--;
            _intelligence -= 1;
        }
        else if (stateNum == 7)//POW大失敗
        {
            Debug.Log("POWペナルティ...");
            _hp--;
            _sanity--;
            _power -= 1;
        }
        else if (stateNum == 8)//EDU大失敗
        {
            Debug.Log("EDUペナルティ...");
            _hp--;
            _sanity--;
            _education -= 1;
        }
        StatesCheck();
    }

    void SanityCheck(int shock)
    {
        if(shock == 0)
        {
            if(_myDice <= _sanity) { _sanity -= 0; }
            else { _sanity -= 1; }
        }
        else if(shock == 1)
        {
            if (_myDice <= _sanity) { _sanity -= 1; }
            else { _sanity -= _random.Next(1,4); }
        }
        else if(shock == 2)
        {
            if (_myDice <= _sanity) { _sanity -= _random.Next(1, 4); }
            else { _sanity -= _random.Next(1, 7); }
        }
        else
        {
            if (_myDice <= _sanity) { _sanity -= _random.Next(1, 7); }
            else { _sanity -= _random.Next(1, 11); }
        }
    }

    void Check(int stateNum)//技能判定を行い処理をそれぞれ行う。
    {

        if(stateNum == 1) //STRの判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(1); }
            else if (_myDice >= 96) { Failed(1); }
            else { Failed(0); }
        }
        if (stateNum == 2) //CONの判定時
        {
            MyDice();
            if (_myDice <= _constitution * 5) { Success(0); }
            else if (_myDice <= 5) { Success(2); }
            else if (_myDice >= 96) { Failed(2); }
            else { Failed(0); }
        }
        if (stateNum == 3) //SIZ判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(3); }
            else if (_myDice >= 96) { Failed(3); }
            else { Failed(0); }
        }
        if (stateNum == 4) //DEX判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(4); }
            else if (_myDice >= 96) { Failed(4); }
            else { Failed(0); }
        }
        if (stateNum == 5) //APP判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(5); }
            else if (_myDice >= 96) { Failed(5); }
            else { Failed(0); }
        }
        if (stateNum == 6) //INT判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(6); }
            else if (_myDice >= 96) { Failed(6); }
            else { Failed(0); }
        }
        if (stateNum == 7) //POW判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(7); }
            else if (_myDice >= 96) { Failed(7); }
            else { Failed(0); }
        }
        if (stateNum == 8) //EDU判定時
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(8); }
            else if (_myDice >= 96) { Failed(8); }
            else { Failed(0); }
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

    void StatesCheck()
    {
        if (_strength < 0) { _strength = 0; }
        if (_constitution < 0) { _constitution = 0; }
        if (_size < 0) { _size = 0; }
        if (_dexterity < 0) { _dexterity = 0; }
        if (_appearance < 0) { _appearance = 0; }
        if (_intelligence < 0) { _intelligence = 0; }
        if (_power < 0) { _power = 0; }
        if (_education < 0) { _education = 0; }

        if (_hp > _maxHp) { _hp = _maxHp; }
        if (_mp > _maxMp) { _mp = _maxMp; }
        if (_sanity > _maxSanity) { _sanity = _maxSanity; }
        if (_strength > 18) { _strength = 18; }
        if (_constitution > 18) { _constitution = 18; }
        if (_size > 18) { _size = 18; }
        if (_dexterity > 18) { _dexterity = 18; }
        if (_appearance > 18) { _appearance = 18; }
        if (_intelligence > 18) { _intelligence = 18; }
        if (_power > 18) { _power = 18; }
        if (_education > 18) { _education = 21; }
    }

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
     $"DB:{_damageBonus}");

        moveStatesText.text =
    ($"HP:{_hp}\n" +
    $"MP:{_mp}\n" +
    $"SAN:{_sanity}\n");//MPを増やす予定。
    }

    void MagicUse() { _mp--; }

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
