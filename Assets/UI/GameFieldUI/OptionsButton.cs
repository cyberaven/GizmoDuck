using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Starter.Instance.MapPrefabHandler.GetCurrentMap.Pause(true);
        Starter.Instance.GameUI.Show(EnumPanelName.PauseMenu);
    }
}
