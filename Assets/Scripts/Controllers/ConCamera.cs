using UnityEngine;

public class ConCamera : Singleton<ConCamera>
{
    private FrostEffect frostEffect;

    public override void Awake()
    {
        base.Awake();

        frostEffect = GetComponent<FrostEffect>();
    }

    public void FrostCamera()
    {
        frostEffect.enabled = true;
        frostEffect.FrostScreen();
    }

    public void UnFrostCamera()
    {
        frostEffect.UnFrostScreen();
    }
}
