using UnityEngine;

public class ButtonExitGame : ButtonMy
{
    protected override void OtherButtonAction()
    {
        Application.Quit();
    }
}
