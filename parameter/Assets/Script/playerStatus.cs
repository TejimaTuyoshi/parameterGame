using UnityEngine;

public class playerStatus : MonoBehaviour
{
    [SerializeField] int _strength = 0;
    [SerializeField] int _constitution = 0;
    [SerializeField] int _size = 0;
    [SerializeField] int _dexterity = 0;
    [SerializeField] int _appearance = 0;
    [SerializeField] int _intelligence = 0;
    [SerializeField] int _power = 0;
    [SerializeField] int _education = 0;
    [SerializeField] int _lucky = 0;//�K�^
    [SerializeField] int _damageBonusNum = 0;//�␳���̌v�Z����ɂ���ۂ̐��l
    [SerializeField] int _damageBonus = 0;//�U�����ɒǉ�����鐔�l�B
    [SerializeField] int _hp = 0;
    void Start()
    {
        
    }

    void Update()
    {
        _damageBonusNum = _strength + _size ;
        _hp = (_constitution + _size) / 2 ;
    }

    public void StartStatus()
    {
        var random = new System.Random();

        DamageBonusNumber();
    }

    void DamageBonusNumber()//damage�{�[�i�X�̕␳���v�Z����ۂ̊֐�
    {
        var random = new System.Random();
        if (_damageBonusNum < 13) { _damageBonus = -1 * random.Next(01, 07) ; }
        else if (_damageBonusNum < 17) { _damageBonus = -1 * random.Next(01, 04); }
        else if (_damageBonusNum < 24) { _damageBonus = 0; }
    }
}
