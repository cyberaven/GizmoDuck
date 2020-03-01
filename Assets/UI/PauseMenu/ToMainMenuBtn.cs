using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToMainMenuBtn : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Starter.Instance.GameUI.ShowOnlyThis(EnumPanelName.MainMenu);
        Starter.Instance.MapPrefabHandler.DestroyCurrentMap();
    }
}
