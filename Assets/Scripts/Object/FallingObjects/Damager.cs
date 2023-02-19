using UnityEngine;

public class Damager : FallingObject
{
    [SerializeField] private TypeDamager typeDamager;

    public TypeDamager GetTypeDamager { get => typeDamager; }
}
