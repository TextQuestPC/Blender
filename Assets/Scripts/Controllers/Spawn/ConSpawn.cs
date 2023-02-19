using UnityEngine;

public class ConSpawn : MonoBehaviour
{
    [SerializeField] private GameObject parentFruit;

    /// <summary>
    /// Создать Fruit в передаваемой позиции
    /// </summary>
    /// <param name="newObject"></param>
    /// <param name="position"></param>
    public void SpawnObject(GameObject newObject, Vector3 position)
    {
        GameObject newObj = Instantiate(newObject, position, Quaternion.identity);
        newObj.transform.SetParent(parentFruit.transform);

        if (newObj.TryGetComponent<Fruit>(out Fruit fruit))
        {
            ManagerObjects.Instance.AddFruit(fruit);
        }
        else if (newObj.TryGetComponent<Damager>(out Damager damager))
        {
            ManagerObjects.Instance.AddDamager(damager);
        }
        else if (newObj.TryGetComponent<BonusTime>(out BonusTime bonusTime))
        {
            ManagerObjects.Instance.AddBonusTime(bonusTime);
        }
    }
}
