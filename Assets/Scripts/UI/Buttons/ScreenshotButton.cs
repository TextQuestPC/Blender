using UnityEngine;

public class ScreenshotButton : ButtonMy
{
    protected override void OtherButtonAction()
    {
        ScreenCapture.CaptureScreenshot("ScrenFruit");
    }
}
