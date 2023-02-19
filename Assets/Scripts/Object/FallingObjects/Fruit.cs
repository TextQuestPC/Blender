using UnityEngine;

public class Fruit : FallingObject
{
    [SerializeField] private TypeFruit TypeFruit;
    [SerializeField] private TypeColor typeColor;

    public TypeFruit GetTypeFruit { get => TypeFruit; }
    public TypeColor GetTypeColor { get => typeColor; }
}
