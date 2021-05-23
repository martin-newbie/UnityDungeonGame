using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildEnemy : EnemyParent
{
    protected override void Awake()
    {
        
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void SetStat()
    {
        m_Hp = 5;
        m_MaxHp = 5;
        m_As = 2;
        m_Def = 0.5f;
        m_Damage = 1;
        m_MobName = "Wild Enemy";
        m_MobType = "Default";
    }
}
