using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour,IAttackable
{
    public Health Health;
    public Health GetHealth => Health;
    public Damage Damage;
    [SerializeField] public float Speed = 5f;
    [SerializeField]public EnumTeam Team { get; set; }
    protected IAttackable Nearest;
    private Rigidbody2D RB;
    private CircleCollider2D CircleCollider2D;
    public UnitEnum UnitType;
    public int Level = 1;
    [SerializeField] public GameObject View;
    [SerializeField] private Gear Gear;

    protected void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
        Refresh();
    }
    
    public void Refresh()
    {
        View.GetComponent<SpriteRenderer>().sprite = Starter.Instance.UnitSpriteHandler.GetSprite(Team, UnitType);
        EntitySettings.UpdateUnit(this);
    }
    public void Hit(Damage damage)
    {
        damage.Hit(Health);
    }
    protected void Update()
    {
        Nearest = Map.GetNearest(this);

        if (Nearest != null && !Damage.InRange(transform,Nearest.transform))
        {
            Vector3 direction = (Nearest.transform.position - transform.position).normalized;            
            RB.MovePosition(transform.position + (Vector3)direction * Speed * Time.fixedDeltaTime);
            RB.velocity = new Vector2(0,0);
            View.transform.up = direction;
        }
    }
    public virtual void Die()
    {
        Gear gear = Instantiate(Gear);
        gear.transform.SetParent(Starter.Instance.MapPrefabHandler.GetCurrentMap.transform);
        gear.transform.position = transform.position;

        FabricaUnit.RecycleUnit(this);
    }
}
public enum UnitEnum
{
    Recruit,
    Tank,
    Swift,
    Police,
    Commander
}
