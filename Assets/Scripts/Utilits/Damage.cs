using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Damage
{
    [SerializeField] private float Range, AttackPeriod;
    [SerializeField] private int MinDamage, MaxDamage;
    private float LastHit = 0;
    public void Refresh(float Range, float AttackPeriod, int MinDamage, int MaxDamage)
    {
        this.Range = Range;
        this.AttackPeriod = AttackPeriod;
        this.MinDamage = MinDamage;
        this.MaxDamage = MaxDamage;
        LastHit = 0;
    }
    public bool InRange(Transform a, Transform b) => (a.position - b.position).sqrMagnitude <= Range * Range;
    public bool CanHit => (LastHit + AttackPeriod <= Time.time);

    public void DoHit()
    {
        LastHit = Time.time;
    }
    public void Hit(Health health)
    {
        health.Hit(UnityEngine.Random.Range(MinDamage, MaxDamage + 1));
    }
}
