using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapPrefabHandler : MonoBehaviour
{
    [SerializeField] private List<Map> Maps = new List<Map>();
    private Map CurrentMap { get; set; }


    public void StartMap(EnumMapName mapName)
    {
        for (int i = 0; i < Maps.Count; i++)
        {
            if (Maps[i].Name == mapName)
            {
                CurrentMap = Instantiate(Maps[i]); 

                Starter.Instance.GameUI.ShowOnlyThis(EnumPanelName.GameFieldUI);
            }
        }
    }
    public Map GetCurrentMap => CurrentMap;

    public void DestroyCurrentMap()
    {
        Time.timeScale = 1;
        Camera.main.transform.SetParent(null);
        
        CurrentMap.Destroy();
    }


}
