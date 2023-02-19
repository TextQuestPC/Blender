public class ButtonInMenu : ButtonMy
{
    protected override void OtherButtonAction()
    {
        ManagerScenes.Instance.LoadMenuScene();
    }
}
