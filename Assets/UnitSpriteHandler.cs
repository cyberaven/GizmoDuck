using UnityEngine;
using System.Collections;

public class UnitSpriteHandler : MonoBehaviour
{
    [SerializeField] private Sprite BotSwift;
    [SerializeField] private Sprite BotTank;
    [SerializeField] private Sprite BotRecruit;

    [SerializeField] private Sprite PoliceRecruit;
    [SerializeField] private Sprite PoliceCommander;

    public Sprite GetSprite(EnumTeam team, UnitEnum unit)
    {
        if(team == EnumTeam.Blue && unit == UnitEnum.Commander)
        {
            return PoliceCommander;
        }
        if (team == EnumTeam.Blue && unit == UnitEnum.Police)
        {
            return PoliceRecruit;
        }
        if (team == EnumTeam.Red && unit == UnitEnum.Tank)
        {
            return BotTank;
        }
        if (team == EnumTeam.Red && unit == UnitEnum.Recruit)
        {
            return BotRecruit;
        }
        if (team == EnumTeam.Red && unit == UnitEnum.Swift)
        {
            return BotSwift;
        }
        throw new System.Exception("No sprite for Team: " + team + " and Unit: " + unit);
    }


}
