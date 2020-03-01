using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] public List<ArrowTower> Towers = new List<ArrowTower>();

    public EnumMapName Name;
    private Hero Hero { get; set; }

    public bool IsPause { get; private set; } = false;
    public BarracksGear BarracksGear;
    /// <summary>
    /// Начиная с нуля
    /// </summary>
    public int WaveNumber = 0;
    private void Start()
    {
        Hero = GetComponentInChildren<Hero>();
        BarracksGear = GetComponentInChildren<BarracksGear>();

    }
    public Hero GetHero()
    {
        return Hero;
    }
    public void Pause(bool pause)
    {
        IsPause = pause;
        Time.timeScale = pause ? 0 : 1;
    }

    public static IAttackable GetNearest(IAttackable attacker)
    {
        int team = (int)attacker.Team ^ 1;
        float minl = 1 << 20, l;
        Vector3 pos = attacker.transform.position;
        IAttackable answer = null;
        foreach (var unit in FabricaUnit.ActiveEntity[team])
            if ((l = (unit.transform.position - pos).sqrMagnitude) < minl)
            {
                minl = l;
                answer = unit;
            }
        return answer;
    }
    public void Destroy()
    {
        Unit[] units = GetComponentsInChildren<Unit>();
        Building[] buildings = GetComponentsInChildren<Building>();
        Hero hero = GetComponentInChildren<Hero>();

        hero.Die();

        for (int i = 0; i < units.Length; i++)
        {
            units[i].Die();
        }
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].Die();
        }
        Destroy(gameObject);
    }
}
