using System.Collections.Generic;
using UnityEngine;

public class ConChooseFruitForSpawn : MonoBehaviour
{
    [SerializeField] private Fruit[] prefabFruit;
    [SerializeField] private Damager[] damagers;
    [SerializeField] private BonusTime[] bonusesTime;

    private DataSpawnObjects dataSpawn;

    [SerializeField] private List<GameObject> objForSpawn = new List<GameObject>();
    private int numberSpawnObj = -1;

    public void SetDataSpawn(DataSpawnObjects dataSpawn)
    {
        this.dataSpawn = dataSpawn;

        CreateListFruitForSpawn();
    }

    private void CreateListFruitForSpawn()
    {
        objForSpawn.Clear();

        for (int i = 0; i < dataSpawn.DataSpawn.Length; i++)
        {
            DataSpawnObjectRandom dataSpawnObj = dataSpawn.DataSpawn[i];

            int countObject = CountProcentObject(dataSpawnObj.ProcentRandom);
            GameObject newObject = null;

            if (dataSpawnObj.TypeObject == TypeObject.Damager)
            {
                foreach (var damager in damagers)
                {
                    if (damager.GetTypeDamager == (dataSpawnObj as DataSpawnDamager).TypeDamager)
                    {
                        newObject = damager.gameObject;
                        break;
                    }
                }
            }
            else if (dataSpawnObj.TypeObject == TypeObject.Fruit)
            {
                foreach (var prefab in prefabFruit)
                {
                    if (prefab.GetTypeFruit == (dataSpawnObj as DataSpawnFruit).TypeFruit)
                    {
                        newObject = prefab.gameObject;
                        break;
                    }
                }
            }
            else if (dataSpawnObj.TypeObject == TypeObject.BonusTime)
            {
                foreach (var bonusTime in bonusesTime)
                {
                    if(bonusTime.GetTypeBonusTime == (dataSpawnObj as DataSpawnBonusTime).TypeBonusTime)
                    {
                        newObject = bonusTime.gameObject;
                    }
                }
            }

            newObject.GetComponent<Rigidbody>().drag = dataSpawnObj.DragObject;

            for (int r = 0; r < countObject; r++)
            {
                objForSpawn.Add(newObject);
            }
        }

        MixObjectsRandom();
        MixObjectsRandom();
    }

    private int CountProcentObject(float procentRandom)
    {
        int count = (int)procentRandom / 2;

        return count;
    }

    private void MixObjectsRandom()
    {
        for (int i = 0; i < objForSpawn.Count; i++)
        {
            int rnd = Random.Range(0, objForSpawn.Count - 1);

            GameObject newObj = objForSpawn[rnd];
            objForSpawn[rnd] = objForSpawn[i];
            objForSpawn[i] = newObj;
        }
    }

    /// <summary>
    /// Выбрать Fruit из возможных в данном рецепте
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectForSpawn()
    {
        numberSpawnObj++;

        if (numberSpawnObj >= objForSpawn.Count)
        {
            numberSpawnObj = 0;
            MixObjectsRandom();
        }

        return objForSpawn[numberSpawnObj];
    }
}
