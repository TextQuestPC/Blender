using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<FallingObject>(out FallingObject fallingObject))
        {
            fallingObject.BoostSpeed();
        }
        else
        {
            Debug.LogError("Не найден компонент Fruit на объекте " + collider.gameObject.name);
        }
    }
}
