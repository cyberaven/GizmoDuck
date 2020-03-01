using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private List<Panel> Panels = new List<Panel>();

    [SerializeField] private EnumPanelName StartPanelName;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        CreateAllPanel();
        HideAll();
        ShowOnlyThis(StartPanelName);
    }

    public void Show(EnumPanelName panelName)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (Panels[i].GetName() == panelName)
            {
                Panels[i].Show();
                return;
            }
        }
    }
    public void ShowOnlyThis(EnumPanelName panelName)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (Panels[i].GetName() == panelName)
            {
                Panels[i].ShowOnlyThis();
                return;
            }
        }
    }
    public void HideAll()
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].Hide();
        }
    }
   public Panel GetPanel(EnumPanelName panelName)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            if (Panels[i].GetName() == panelName)
            {
                return Panels[i];
                
            }
        }
        throw new System.Exception("No panel with name: " + panelName.ToString());
    }
    private void CreateAllPanel()
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i] = Instantiate(Panels[i], transform);
        }
    }

}