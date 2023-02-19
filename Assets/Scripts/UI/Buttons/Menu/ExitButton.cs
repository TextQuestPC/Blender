using UnityEngine;

public class ExitButton : ButtonMy
{
    protected override void OtherButtonAction()
    {
        Application.Quit();
    }
}
