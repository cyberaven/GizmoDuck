using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IAttackable
{
    public Health GetHealth => Health;
    public Health Health;
    [SerializeField] private EnumTeam Team_;
    
    [SerializeField] public EnumTeam Team { get=>Team_; set=>Team_ = value; }
    public int Level =1;
    protected void Start()
    {
        FabricaUnit.ActiveEntity[(int)Team].Add(this);
    }

    public void Hit(Damage damage)
    {
        damage.Hit(Health);
    }
    public void Die()
    {
        FabricaUnit.ActiveEntity[(int)Team].Remove(this);

        Destroy(gameObject);
    }
    public void LevelUp()
    {
        Level++;
        if (this is ArrowTower tower)
            EntitySettings.UpdateTower(tower);
    }
}


