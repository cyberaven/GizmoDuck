using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FabricaBullet 
{
    static Bullet BulletPrefab;
    static Pool<Bullet> BulletPool;
    static FabricaBullet()
    {
        BulletPrefab = Resources.Load<Bullet>("Bullets/Arrow");
        BulletPool = new Pool<Bullet>(BulletPrefab);


    }
    public static Bullet GetBullet()
    {
        return BulletPool.Get();
    }
    public static void RecycleBullet(Bullet t)
    {
        BulletPool.Set(t);
    }
}
