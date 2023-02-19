public class ButtonSetting : ButtonMy
{
    protected override void OtherButtonAction()
    {
        SettingsPanel.Instance.ShowPanel();
    }
}
