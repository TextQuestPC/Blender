using System.Collections.Generic;
using UnityEngine;

public class DataNeedFruit : MonoBehaviour
{
    private List<DataPartNeedFruit> partsNeedFruits;

    public List<DataPartNeedFruit> GetPartsNeedFruits { get => partsNeedFruits; }

    public DataNeedFruit(List<DataPartNeedFruit> partsNeedFruit)
    {
        this.partsNeedFruits = partsNeedFruit;
    }

    public void ReduceFruit(TypeFruit typeFruit)
    {
        foreach (var part in partsNeedFruits)
        {
            if (part.GetTypeFruit == typeFruit)
            {
                part.ReduceCount();

                return;
            }
        }
    }

    public bool CheckHaveNeedFruit()
    {
        foreach (var part in partsNeedFruits)
        {
            if (part.GetCountFruit > 0)
                return true;
        }

        return false;
    }
}
