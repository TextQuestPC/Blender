using UnityEngine;

public class BlenderFloorCollision : MonoBehaviour
{
    [SerializeField] private EffectSlicing effectSlicing;
    [SerializeField] private BlenderAnimation blenderAnimation;

    private void OnCollisionEnter(Collision collision)
    {
        if (!CheckPositionCollision())
            return;

        string tag = collision.gameObject.tag;

        collision.gameObject.GetComponent<FallingObject>().TouchFloorBlender();

        if (tag == DataTags.Fruit.ToString())
        {
            if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
            {
                effectSlicing.ShowSliceFruit(fruit);

                ManagerLevel.Instance.CheckFruit(fruit);
                ManagerObjects.Instance.DestroyFruit(fruit);
                blenderAnimation.CutFruit();
            }
            else
            {
                Debug.LogError("Не найден компонент Fruit на объекте " + collision.gameObject.name);
            }
        }
        else if (tag == DataTags.Damager.ToString())
        {
            if (collision.gameObject.TryGetComponent<Damager>(out Damager damager))
            {
                if (damager.GetTypeDamager == TypeDamager.Ice)
                {
                    blenderAnimation.FreezeBlender();
                }
                else if (damager.GetTypeDamager == TypeDamager.Tree)
                {
                    blenderAnimation.EffectDamageBlender();
                }

                ManagerLevel.Instance.CheckDamager(damager);
                ManagerObjects.Instance.DestroyDamager(damager);
            }
            else
            {
                Debug.LogError("Не найден компонент Damager на объекте " + collision.gameObject.name);
            }
        }
        else if (tag == DataTags.BonusTime.ToString())
        {
            if (collision.gameObject.TryGetComponent<BonusTime>(out BonusTime bonusTime))
            {
                ManagerTime.Instance.AddTime(bonusTime.GetTypeBonusTime);
                ManagerObjects.Instance.DestroyBonusTime(bonusTime);
            }
            else
            {
                Debug.LogError("Не найден компонент BonusTime на объекте " + collision.gameObject.name);
            }
        }
    }

    private bool CheckPositionCollision()
    {
        return true;
    }
}
