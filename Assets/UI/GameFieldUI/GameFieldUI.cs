using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameFieldUI : MonoBehaviour
{
    [SerializeField] public VariableJoystick JoystickUI;
    [SerializeField] public Text HealthText;
    [SerializeField] public Text GearsText;

    public VariableJoystick GetJoystickUI()
    {
        return JoystickUI;
    }

    private void Update()
    {
        HealthText.text = "" + Starter.Instance.MapPrefabHandler.GetCurrentMap.GetHero().Health.GetHP();
        GearsText.text = "" + Starter.Instance.MapPrefabHandler.GetCurrentMap.GetHero().Gears;
    }
}
