using UnityEngine;

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
