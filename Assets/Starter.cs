using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public static Starter Instance;

    [SerializeField] public GameUI GameUI;
    [SerializeField] public MapPrefabHandler MapPrefabHandler;
    [SerializeField] public UnitSpriteHandler UnitSpriteHandler;

    private void Awake()
    {
        Instance = this;

        GameUI = Instantiate(GameUI);
        MapPrefabHandler = Instantiate(MapPrefabHandler);
        UnitSpriteHandler = Instantiate(UnitSpriteHandler);
    }
}
