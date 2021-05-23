using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyParent : MonoBehaviour
{
    public float m_Hp;
    public float m_MaxHp;
    public float m_As;
    public float m_Def;
    public float m_Damage;
    public string m_MobName;
    public string m_MobType;
    public bool isAttack = false;

    bool isAttacking = false;
    bool isDestroy = false;

    protected virtual void Awake()
    {
        SetStat();
    }
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        IsDestroy();
        if(isAttack && !isAttacking)
        {
            isAttacking = true;
            InvokeRepeating("Attack", 0, m_As);
        }
        if(!isAttack)
        {
            isAttacking = false;
        }
    }

    public void Attack()
    {
        GameObject.Find("Player").GetComponent<PlayerStatus>().curHp -= m_Damage;
    }

    public void IsDestroy()
    {
        if(m_Hp <= 0)
        {
            isDestroy = true;
        }
    }

    protected abstract void SetStat();
}
