using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private float WaitTime = 5f;
    private float Timer = 0f;

    private void Update()
    {
        Timer += 0.016f;
        
        Debug.Log(Timer);

        if(Timer >= WaitTime)
        {
            Starter.Instance.GameUI.ShowOnlyThis(EnumPanelName.MainMenu);
            Timer = 0;
        }
    }
}
