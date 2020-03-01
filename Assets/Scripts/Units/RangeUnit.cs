using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeUnit : Unit
{

 
    protected new void Update()
    {
        if (!Starter.Instance.MapPrefabHandler.GetCurrentMap.IsPause)
        {
            base.Update();
            if (Nearest != null && Damage.InRange(transform, Nearest.transform) && Damage.CanHit)
            {
                Damage.DoHit();
                Bullet bullet = FabricaBullet.GetBullet();
                bullet.Shot((Vector2)transform.position, (Vector2)Nearest.transform.position, (attackable) => attackable.Team != Team, Damage);
            }
        }
    }
    
}
