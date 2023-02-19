using UnityEngine;

public class BonusTime : FallingObject
{
    [SerializeField] private TypeBonusTime valueTime;

    public TypeBonusTime GetTypeBonusTime { get => valueTime; }
}
