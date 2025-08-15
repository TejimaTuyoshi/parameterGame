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

    //�v�Z�ɂ���ďo���p�����[�^
    [SerializeField] int _lucky = 0;//�K�^
    [SerializeField] int _damageBonusNum = 0;//�␳���̌v�Z����ɂ���ۂ̐��l
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
        if (stateNum == 1) //STR������
        {
            Debug.Log($"{_myDice}:����");
            checkText.text = ($"{_myDice}:����!");
        }
    }

    void Failed(int stateNum)//���莸�s���̏���
    {
        if (stateNum == 1) //STR���s��
        {
            Debug.Log($"{_myDice}:���s");
            checkText.text = ($"{_myDice}:���s...");
        }
    }

    void Check(int stateNum)//�Z�\������s�����������ꂼ��s���B
    {
        if(stateNum == 1) 
        {
            MyDice();
            if (_myDice <= _strength * 5) { Success(1); }
            else { Failed(1); }
        }
    }

    public void CheckSTR() { Check(1); } //STR�Ŕ�����s���ꍇ

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
