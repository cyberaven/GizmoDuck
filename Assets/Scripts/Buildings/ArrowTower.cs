using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Building
{
    public Damage Damage;
    private IAttackable Nearest;

    [SerializeField] private GameObject View;

    private void Start()
    {
        EntitySettings.UpdateTower(this);
        base.Start();
    }
    private void Update()
    {
        if (!Starter.Instance.MapPrefabHandler.GetCurrentMap.IsPause)
        {
            Nearest = Map.GetNearest(this);
            if (Nearest != null && Damage.InRange(transform, Nearest.transform) && Damage.CanHit)
            {                
                Damage.DoHit();
                Bullet bullet = FabricaBullet.GetBullet();
                bullet.Shot((Vector2)transform.position, (Vector2)Nearest.transform.position, (attackable) => attackable.Team != Team, Damage);
                View.transform.up = transform.position - Nearest.transform.position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Gear")
        {
            Health.Hit(-15);
            Destroy(collision.gameObject);
        }
    }   
}
