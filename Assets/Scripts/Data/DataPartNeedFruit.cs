using UnityEngine;

public class DataPartNeedFruit
{
    private TypeFruit typeFruit;
    private int countFruit;

    public TypeFruit GetTypeFruit { get => typeFruit; }
    public int GetCountFruit { get => countFruit; }

    public DataPartNeedFruit(TypeFruit typeFruit, int countFruit)
    {
        this.typeFruit = typeFruit;
        this.countFruit = countFruit;
    }

    public void ReduceCount()
    {
        countFruit--;
    }
}
