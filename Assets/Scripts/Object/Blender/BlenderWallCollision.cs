using UnityEngine;

public class BlenderWallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == DataTags.Fruit.ToString())
        {
            if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
            {
                fruit.TouchWallBlender();
            }
            else
            {
                Debug.LogError("Не найден компонент Fruit на объекте " + collision.gameObject.name);
            }
        }
    }
}
