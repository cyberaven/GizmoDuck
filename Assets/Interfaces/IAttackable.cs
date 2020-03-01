using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    Transform transform { get; }
    EnumTeam Team { get;  set; }
    Health GetHealth { get; }
     void Hit(Damage damage);
    void Die();
}
