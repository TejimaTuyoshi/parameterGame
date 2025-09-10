using UnityEngine;
using UnityEngine.UI;

public class player : GameJudger
{
    System.Random _random = new System.Random();
    int _myDice = 0;//���������s���𔻒肷�邽�߂̐��l
    //�����_���Ō��߂�p�����[�^
    int _strength = 0;//�ؗ�
    int _constitution = 0;//�̗�
    int _size = 0;//�̊i
    int _dexterity = 0;//�q����
    int _appearance = 0;//�O��
    int _intelligence = 0;//�m��
    int _power = 0;//���_��
    int _education = 0;//����

    //�v�Z�ɂ���ďo���p�����[�^
    int _lucky = 0;//�K�^
    int _damageBonusNum = 0;//�␳���̌v�Z����ɂ���ۂ̐��l
    int _damageBonus = 0;//�U�����ɒǉ�����鐔�l�B
    [SerializeField] int _hp = 0;
    [SerializeField] int _mp = 0;
    [SerializeField] int _sanity = 0;
    int _maxHp = 0;
    int _maxMp = 0;
    int _maxSanity = 0;

    [SerializeField] Text statesText;//�e�L�X�g�ɂăX�e�[�^�X���o��
    [SerializeField] Text moveStatesText;

    [SerializeField] Text checkText;//�e�L�X�g�ɂĔ�����o��

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

    void Success(int stateNum) //���萬�����̏���
    {
        Debug.Log($"{_myDice}:����");
        checkText.text = ($"{_myDice}:����!");
        successCount.CountUp();

        if (stateNum == 0 && _hp <= (_constitution + _size) / 2)
        {
            MyDice();
            if (_myDice <= _dexterity + _intelligence)
            {
                Debug.Log("�񕜐���");
                _hp++;
            }
            else { Debug.Log("�񕜎��s"); }
        }
         else if (stateNum == 1) //STR�听����
        {
            Debug.Log("STR��������");
            _sanity++;
            _strength++;
        }
        else if (stateNum == 2) //CON�听����
        {
            Debug.Log("CON��������");
            _sanity++;
            _constitution++;
        }
        else if (stateNum == 3) //SIZ�听����
        {
            Debug.Log("SIZ��������");
            _sanity++;
            _size++;
        }
        else if (stateNum == 4) //DEX�听����
        {
            Debug.Log("DEX��������");
            _sanity++;
            _dexterity++;
        }
        else if (stateNum == 5) //APP�听����
        {
            Debug.Log("APP��������");
            _sanity++;
            _appearance++;
        }
        else if (stateNum == 6) //INT�听����
        {
            Debug.Log("INT��������");
            _sanity++;
            _intelligence++;
        }
        else if (stateNum == 7) //POW�听����
        {
            Debug.Log("POW��������");
            _sanity++;
            _power++;
        }
        else if (stateNum == 8) //EDU�听����
        {
            Debug.Log("EDU��������");
            _sanity++;
            _education++;
        }
        StatesCheck();
    }

    void Failed(int stateNum)//���莸�s���̏���
    {
        Debug.Log($"{_myDice}:���s");
        checkText.text = ($"{_myDice}:���s...");

        if (stateNum == 0)//�ʏ편�s
        {
            _hp--;
        }
        else if (stateNum == 1)//STR�厸�s
        {
            Debug.Log("STR�y�i���e�B...");
            _hp--;
            _sanity--;
            _strength -= 1;
        }
        else if (stateNum == 2)//CON�厸�s
        {
            Debug.Log("CON�y�i���e�B...");
            _hp--;
            _sanity--;
            _constitution -= 1;
        }
        else if (stateNum == 3)//SIZ�厸�s
        {
            Debug.Log("SIZ�y�i���e�B...");
            _hp--;
            _sanity--;
            _size -= 1;
        }
        else if (stateNum == 4)//DEX�厸�s
        {
            Debug.Log("DEX�y�i���e�B...");
            _hp--;
            _sanity--;
            _dexterity -= 1;
        }
        else if (stateNum == 5)//APP�厸�s
        {
            Debug.Log("APP�y�i���e�B...");
            _hp--;
            _sanity--;
            _appearance -= 1;
        }
        else if (stateNum == 6)//INT�厸�s
        {
            Debug.Log("INT�y�i���e�B...");
            _hp--;
            _sanity--;
            _intelligence -= 1;
        }
        else if (stateNum == 7)//POW�厸�s
        {
            Debug.Log("POW�y�i���e�B...");
            _hp--;
            _sanity--;
            _power -= 1;
        }
        else if (stateNum == 8)//EDU�厸�s
        {
            Debug.Log("EDU�y�i���e�B...");
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

    void Check(int stateNum)//�Z�\������s�����������ꂼ��s���B
    {

        if(stateNum == 1) //STR�̔��莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(1); }
            else if (_myDice >= 96) { Failed(1); }
            else { Failed(0); }
        }
        if (stateNum == 2) //CON�̔��莞
        {
            MyDice();
            if (_myDice <= _constitution * 5) { Success(0); }
            else if (_myDice <= 5) { Success(2); }
            else if (_myDice >= 96) { Failed(2); }
            else { Failed(0); }
        }
        if (stateNum == 3) //SIZ���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(3); }
            else if (_myDice >= 96) { Failed(3); }
            else { Failed(0); }
        }
        if (stateNum == 4) //DEX���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(4); }
            else if (_myDice >= 96) { Failed(4); }
            else { Failed(0); }
        }
        if (stateNum == 5) //APP���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(5); }
            else if (_myDice >= 96) { Failed(5); }
            else { Failed(0); }
        }
        if (stateNum == 6) //INT���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(6); }
            else if (_myDice >= 96) { Failed(6); }
            else { Failed(0); }
        }
        if (stateNum == 7) //POW���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(7); }
            else if (_myDice >= 96) { Failed(7); }
            else { Failed(0); }
        }
        if (stateNum == 8) //EDU���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(0); }
            else if (_myDice <= 5) { Success(8); }
            else if (_myDice >= 96) { Failed(8); }
            else { Failed(0); }
        }
    }

    public void CheckSTR() { Check(1); } //STR�Ŕ�����s���ꍇ
    public void CheckCON() { Check(2); } //CON�Ŕ�����s���ꍇ
    public void CheckSIZ() { Check(3); } //SIZ�Ŕ�����s���ꍇ
    public void CheckDEX() { Check(4); } //DEX�Ŕ�����s���ꍇ
    public void CheckAPP() { Check(5); } //APP�Ŕ�����s���ꍇ
    public void CheckINT() { Check(6); } //INT�Ŕ�����s���ꍇ
    public void CheckPOW() { Check(7); } //POW�Ŕ�����s���ꍇ
    public void CheckEDU() { Check(8); } //EDU�Ŕ�����s���ꍇ

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
    $"SAN:{_sanity}\n");//MP�𑝂₷�\��B
    }

    void MagicUse() { _mp--; }

    void DamageBonusNumber()//damage�{�[�i�X�̕␳���v�Z����ۂ̊֐�
    {//�U�����ɖ��񐔒l�Ƃ��ďo���\��
        if (_damageBonusNum < 13) { _damageBonus = -1 * _random.Next(01, 07); }
        else if (_damageBonusNum < 17) { _damageBonus = -1 * _random.Next(01, 05); }
        else if (_damageBonusNum < 25) { _damageBonus = 0; }
        else if (_damageBonusNum < 33) { _damageBonus = _random.Next(01, 05); }
        else if (_damageBonusNum < 40) { _damageBonus = _random.Next(01, 07); }
        else { _damageBonus = _random.Next(01, 11); }//�{���͂��肦�Ȃ����G���[������邽�߂ɔO�̂��߂ɍ쐬�B
    }
}
