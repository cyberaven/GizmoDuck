using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : Unit
{
  
    private void OnCollisionStay2D(Collision2D collision)
    {
        IAttackable target = collision.gameObject.GetComponent<IAttackable>();
        if (target == null)
        {
            return;
        }
        if(target.Team != Team &&  Damage.CanHit)
        {
            Damage.DoHit();
            target.Hit(Damage);
        }
    }
    private new void Update()
    {
        base.Update();
    }
}
