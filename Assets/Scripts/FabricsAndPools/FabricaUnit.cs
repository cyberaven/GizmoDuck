using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FabricaUnit
{
    public static List<IAttackable>[] ActiveEntity = new List<IAttackable>[2] { new List<IAttackable>(), new List<IAttackable>() };
    static MeleeUnit Melee;
    static RangeUnit Ranger;
    static Commander Commander;
    static Pool<MeleeUnit> MeleePool;
    static Pool<RangeUnit> RangerPool;
    static Pool<Commander> CommanderPool;
    static FabricaUnit()
    {
        Melee = Resources.Load<MeleeUnit>("Units/Melee");
        MeleePool = new Pool<MeleeUnit>(Melee);
        Ranger = Resources.Load<RangeUnit>("Units/Ranger");
        RangerPool = new Pool<RangeUnit>(Ranger);
        Commander = Resources.Load<Commander>("Units/Commander");
        CommanderPool = new Pool<Commander>(Commander);


    }
    public static Unit GetUnit(UnitEnum unit, EnumTeam team, int Level)
    {
        Unit t = null;
        switch(unit)
        {
            case UnitEnum.Recruit:
            case UnitEnum.Police: t = MeleePool.Get();break;
            case UnitEnum.Swift:
            case UnitEnum.Tank: t = RangerPool.Get();break;
            case UnitEnum.Commander: t = CommanderPool.Get();break;
        }
        t.Level = Level;
        t.Team = team;
        t.UnitType = unit;
        t.Refresh();
        ActiveEntity[(int)team].Add(t);
        return t;
    }
    public static void RecycleUnit(Unit t)
    {
        ActiveEntity[(int)t.Team].Remove(t);
        if (t is MeleeUnit melee)
            MeleePool.Set(melee);
        else if (t is Commander commander)
            CommanderPool.Set(commander);
        else if (t is RangeUnit range)
            RangerPool.Set(range);
    }
}
