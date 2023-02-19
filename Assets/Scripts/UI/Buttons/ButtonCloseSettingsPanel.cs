using UnityEngine;

public class ButtonCloseSettingsPanel : ButtonMy
{
    protected override void OtherButtonAction()
    {
        SettingsPanel.Instance.HidePanel();
    }
}
