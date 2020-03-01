using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Health 
{
    [SerializeField] public int MaxHP, HP;
    public bool IsDead => HP <= 0;
    public HealthBar Bar;
    public IAttackable Entity;
    public void Refresh(int maxHP)
    {
        HP = MaxHP = maxHP;
        Bar?.UpdateHP(1);
    }
    public Health(int MaxHealth)
    {
        MaxHP = HP = MaxHealth;
    }
    public void Hit(int damage)
    {
        int oldHP = HP;
        HP -= damage;
        if (HP > MaxHP)
            HP = MaxHP;
        Bar.UpdateHP((float)HP / MaxHP);

        if (oldHP > 0 && HP <= 0)
            Entity.Die();
    }
    public int GetHP()
    {
        return HP;
    }
}
