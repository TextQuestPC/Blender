public class ButtonRestartLevel : ButtonMy
{
    protected override void OtherButtonAction()
    {
        ManagerCanvaces.Instance.ClickRestartLevel();
    }
}
