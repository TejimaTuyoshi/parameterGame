using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    System.Random _random = new System.Random();
    int _myDice = 0;//���������s���𔻒肷�邽�߂̐��l

    //�����_���Ō��߂�p�����[�^
    [SerializeField] int _strength = 0;//�ؗ�
    [SerializeField] int _constitution = 0;//�̗�
    [SerializeField] int _size = 0;//�̊i
    [SerializeField] int _dexterity = 0;//�q����
    [SerializeField] int _appearance = 0;//�O��
    [SerializeField] int _intelligence = 0;//�m��
    [SerializeField] int _power = 0;//���_��
    [SerializeField] int _education = 0;//����

    //�X�̋Z�\�ł̐����J�E���g
    int _strengthCount = 0;//�ؗ�
    int _constitutionCount = 0;//�̗�
    int _sizeCount = 0;//�̊i
    int _dexterityCount = 0;//�q����
    int _appearanceCount = 0;//�O��
    int _intelligenceCount = 0;//�m��
    int _powerCount = 0;//���_��
    int _educationCount = 0;//����

    //�v�Z�ɂ���ďo���p�����[�^
    [SerializeField] int _lucky = 0;//�K�^
    int _damageBonusNum = 0;//�␳���̌v�Z����ɂ���ۂ̐��l
    [SerializeField] int _damageBonus = 0;//�U�����ɒǉ�����鐔�l�B
    [SerializeField] int _hp = 0;


    [SerializeField] Text statesText;//�e�L�X�g�ɂăX�e�[�^�X���o��

    [SerializeField] Text checkText;//�e�L�X�g�ɂĔ�����o��


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

    void Success(int stateNum) //���萬�����̏���
    {
        Debug.Log($"{_myDice}:����");
        checkText.text = ($"{_myDice}:����!");
        if (stateNum == 1) //STR������
        {
            _strengthCount++;
            if (_strengthCount > 2)
            {
                _strength++;
                _strengthCount = 0;
            }
        }
        if (stateNum == 2) //CON������
        {
            _constitutionCount++;
            if (_constitutionCount > 2)
            {
                _constitution++;
                _constitutionCount = 0;
            }
        }
        if (stateNum == 3) //SIZ������
        {
            _sizeCount++;
            if (_sizeCount > 2)
            {
                _size++;
                _sizeCount = 0;
            }
        }
        if (stateNum == 4) //DEX������
        {
            _dexterityCount++;
            if (_dexterityCount > 2)
            {
                _dexterity++;
                _dexterityCount = 0;
            }
        }
        if (stateNum == 5) //APP������
        {
            _appearanceCount++;
            if (_appearanceCount > 2)
            {
                _appearance++;
                _appearanceCount = 0;
            }
        }
        if (stateNum == 6) //INT������
        {
            _intelligenceCount++;
            if (_intelligenceCount > 2)
            {
                _intelligence++;
                _intelligenceCount = 0;
            }
        }
        if (stateNum == 7) //POW������
        {
            _powerCount++;
            if (_powerCount > 2)
            {
                _power++;
                _powerCount = 0;
            }
        }
        if (stateNum == 8) //EDU������
        {
            _educationCount++;
            if (_educationCount > 2)
            {
                _education++;
                _educationCount = 0;
            }
        }
    }

    void Failed()//���莸�s���̏���
    {
        Debug.Log($"{_myDice}:���s");
        checkText.text = ($"{_myDice}:���s...");
        _hp -= 1;
    }

    void Check(int stateNum)//�Z�\������s�����������ꂼ��s���B
    {
        if(stateNum == 1) //STR�̔��莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(1); }
            else { Failed(); }
        }
        if (stateNum == 2) //CON�̔��莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(2); }
            else { Failed(); }
        }
        if (stateNum == 3) //SIZ���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(3); }
            else { Failed(); }
        }
        if (stateNum == 4) //DEX���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(4); }
            else { Failed(); }
        }
        if (stateNum == 5) //APP���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(5); }
            else { Failed(); }
        }
        if (stateNum == 6) //INT���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(6); }
            else { Failed(); }
        }
        if (stateNum == 7) //POW���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(7); }
            else { Failed(); }
        }
        if (stateNum == 8) //EDU���莞
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(8); }
            else { Failed(); }
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
