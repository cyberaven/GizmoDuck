using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMapBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EnumMapName MapName;  
      
    public void OnPointerClick(PointerEventData eventData)
    {
        Starter.Instance.MapPrefabHandler.StartMap(MapName);      
    }
}
