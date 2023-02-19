using UnityEngine;

public class DestoyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            ManagerObjects.Instance.DestroyFruit(fruit);
        }
        else if (collision.gameObject.TryGetComponent<Damager>(out Damager damager))
        {
            ManagerObjects.Instance.DestroyDamager(damager);
        }
        else if (collision.gameObject.TryGetComponent<BonusTime>(out BonusTime bonusTime))
        {
            ManagerObjects.Instance.DestroyBonusTime(bonusTime);
        }
    }
}
