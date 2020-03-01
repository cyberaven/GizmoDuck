using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : RangeUnit
{  
    public override void Die()
    {
        var mech = Starter.Instance.MapPrefabHandler.GetCurrentMap.BarracksGear;
        mech.gameObject.SetActive(true);
        mech.transform.position = transform.position;

        base.Die();
    }
}
