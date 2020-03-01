using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IAttackable
{
    public Health GetHealth => Health;
    public Health Health;
    public Damage Heal;
    [SerializeField] public float Speed = 5f;
    private Rigidbody2D rb;

    [SerializeField] private Gear Gear;
    public int Gears = 0;
    public float DistanceToTowerForHeal = 100f;
    
    public bool BarracksGear = false;

    [SerializeField] private GameObject View;
    [SerializeField] private VariableJoystick VariableJoystick;

    private float healCount = 0.5f;
    private float healTimer = 0;

    public EnumTeam Team { get; set; } = EnumTeam.Blue;



    public void Hit(Damage damage)
    {
        damage.Hit(Health);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Panel panel = Starter.Instance.GameUI.GetPanel(EnumPanelName.GameFieldUI);
        VariableJoystick = panel.GetComponent<GameFieldUI>().GetJoystickUI();

        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = Vector3.back;

        FabricaUnit.ActiveEntity[(int)Team].Add(this);
    }
    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * VariableJoystick.Vertical + Vector2.right * VariableJoystick.Horizontal;
        View.transform.up = direction;
        rb.MovePosition(transform.position + (Vector3)direction * Speed * Time.fixedDeltaTime);

        HealNearTower();

        CheckHP();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Barrack")
        {
            Barrack barrack = collision.gameObject.GetComponent<Barrack>();
            if (barrack.Team == Team && BarracksGear)
            {
                BarracksGear = false;
                barrack.GiveGear();
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gear")
        {
            if (collision.gameObject.GetComponent<Gear>().TakeEnable == true)
            {
                Gears++;
                Destroy(collision.gameObject);
            }
        }
    }
    public void Die()
    {
        FabricaUnit.ActiveEntity[(int)Team].Remove(this);
    }
    private void HealNearTower()
    {
        Map currentMap = Starter.Instance.MapPrefabHandler.GetCurrentMap;

        if (Gears > 0)
        {
            foreach (ArrowTower tower in currentMap.Towers)
            {
                if (tower != null)
                {
                    if (Vector3.Distance(transform.position, tower.transform.position) < DistanceToTowerForHeal && tower.Health.HP < tower.Health.MaxHP)
                    {
                        healTimer += Time.fixedDeltaTime;

                        if (healTimer >= healCount)
                        {
                            Gears--;
                            Gear gear = Instantiate(Gear, currentMap.transform);
                            gear.TakeEnable = false;
                            gear.transform.position = transform.position;
                            gear.MoveTarget(tower.transform.position);
                            healTimer = 0;
                        }
                    }
                }
            }
        }        
    }
    private void CheckHP()
    {
        if(Health.HP <= 0)
        {
            Camera.main.transform.SetParent(null);
            Starter.Instance.MapPrefabHandler.DestroyCurrentMap();
            Starter.Instance.GameUI.ShowOnlyThis(EnumPanelName.LosePanel);
        }
    }
}
