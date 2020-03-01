using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour, IPanel
{
    [SerializeField] private EnumPanelName Name;

    public EnumPanelName GetName()
    {
        return Name;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void ShowOnlyThis()
    {
        Starter.Instance.GameUI.HideAll();
        Show();
    }
}
