using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntitySettings 
{

   public static void UpdateUnit(Unit unit)
    {
        int hp, damage;
        float range, period;
        int lvl = unit.Level - 1;
        hp = 10; damage = 1; range = 0; period = 1;
        switch (unit.UnitType)
        {
            case UnitEnum.Police:hp = 100 + 50 * lvl;damage = 20 + 20 * lvl; break;
            case UnitEnum.Commander: hp = 200 + 100 * lvl; range = 2; damage = 40 + 40 * lvl; break;
            case UnitEnum.Recruit: hp = 100; damage = 50; break;
            case UnitEnum.Tank: hp = 600;period = 2.5f;range = 1; damage = 200; break;
            case UnitEnum.Swift: hp = 50;period = 0.2f;range = 2; damage = 13; break;
        }
        unit.Health.Refresh(hp); unit.Damage.Refresh(range, period, damage, damage);
    }
    public static void UpdateTower(ArrowTower tower)
    {
        int hp, damage;
        float range, period;
        int lvl = tower.Level - 1;
        hp = 400 + 400*lvl; damage = 50+50*lvl; range = lvl > 1 ? 6 : 3;
        period = 0.5f;


        tower.Health.Refresh(hp); tower.Damage.Refresh(range, period, damage, damage);
    }

}
