using System;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Building
{
    [SerializeField] public List<SpawnParametr> Spawn;
    [SerializeField] public float CoolDawn;
    [SerializeField] private Sprite EnemySprite;

    private float LastSpawn = -100000;
    public bool HaveGear = false;
    public Barrack EnemyBarrack;
    public void GiveGear()
    {
        HaveGear = true;
        LastSpawn = Time.time;
        Debug.Log("I have GEAR");
    }

    private void Start()
    {
        if(Team == EnumTeam.Red)
        {
            GetComponent<SpriteRenderer>().sprite = EnemySprite;
        }
    }
    private void Update()
    {
        if (!Starter.Instance.MapPrefabHandler.GetCurrentMap.IsPause)
        {
            if ((HaveGear || Team != EnumTeam.Blue) && LastSpawn + CoolDawn < Time.time)
            {
                LastSpawn = Time.time;
                int wave = Starter.Instance.MapPrefabHandler.GetCurrentMap.WaveNumber;
                SpawnParametr spawn = wave < Spawn.Count ? Spawn[wave] : Spawn[Spawn.Count - 1];

                foreach(SpawnPair pair in spawn.Parametr)
                {
                    for (int j = 0; j < pair.Count; j++)
                    {
                        var t = FabricaUnit.GetUnit(pair.Type, Team, Level);
                        t.transform.position = transform.position + (Vector3)UnityEngine.Random.insideUnitCircle;
                    }
                }
                
                HaveGear = false;
                if (Team == EnumTeam.Red)
                    Starter.Instance.MapPrefabHandler.GetCurrentMap.WaveNumber++;
            }
        }
    }
}
[Serializable]
public class SpawnParametr
{
    public SpawnPair[] Parametr;
}
[Serializable]
public class SpawnPair
{
    public UnitEnum Type;
    public int Count;
}
