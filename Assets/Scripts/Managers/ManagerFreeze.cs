using System.Collections;
using UnityEngine;

public class ManagerFreeze : Singleton<ManagerFreeze>
{
    [SerializeField] private Blender blender;

    private float timeFreeze = 2f;

    public void FreezeBlender()
    {
        ManagerSwipeTap.Instance.ChangeCanSwipeTap(false);
        blender.Freeze();
        ConCamera.Instance.FrostCamera();

        StartCoroutine(CoWaitFreeze());
    }

    private IEnumerator CoWaitFreeze()
    {
        yield return new WaitForSeconds(timeFreeze);

        ManagerSwipeTap.Instance.ChangeCanSwipeTap(true);
        blender.EndFreeze();
        ConCamera.Instance.UnFrostCamera();
    }
}
