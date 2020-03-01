using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnToGameButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Starter.Instance.GameUI.ShowOnlyThis(EnumPanelName.GameFieldUI);
        Starter.Instance.MapPrefabHandler.GetCurrentMap.Pause(false);
    }
}
