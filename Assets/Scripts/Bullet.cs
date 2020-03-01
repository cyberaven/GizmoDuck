using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float Speed = 4f;
    public delegate bool Shotable(IAttackable target);
    private Shotable CanShot;
    private Damage Damage;

    Vector3 From,To;
    float R = 0, T;

    [SerializeField] private GameObject View;

    public void Shot(Vector2 from, Vector2 to, Shotable shotable, Damage damage)
    {
        transform.position = from;
        CanShot = shotable;
        Damage = damage;
        From = from;
        To = to;
        T = Speed / (from - to).magnitude;
        R = 0;
        View.transform.up = -(from - to);
    }
    void Update()
    {

        transform.position = Vector3.LerpUnclamped(From, To, R * T);
        R += Time.deltaTime;
        if(R*T>1)
        {
            FabricaBullet.RecycleBullet(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IAttackable target = collision.gameObject.GetComponent<IAttackable>();
        if (target != null && CanShot(target))
        {
            target.Hit(Damage);
            FabricaBullet.RecycleBullet(this);

        }
    }
}
