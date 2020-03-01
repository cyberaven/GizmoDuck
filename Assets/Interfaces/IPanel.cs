using UnityEngine;
using System.Collections;

public interface IPanel
{
    EnumPanelName GetName();
    void Show();
    void ShowOnlyThis();
    void Hide();
}
