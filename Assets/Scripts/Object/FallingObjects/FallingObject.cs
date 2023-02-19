using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private AudioClip soundFall;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Остановить движение Fruit
    /// </summary>
    public void StopObject()
    {
        if (rigidBody != null)
            rigidBody.useGravity = false;
    }

    /// <summary>
    /// Fruit продолжает движение после паузы
    /// </summary>
    public void GoObject()
    {
        if (rigidBody != null)
            rigidBody.useGravity = true;
    }

    /// <summary>
    /// Включение возможности смещения по оси X
    /// </summary>
    public void TouchWallBlender()
    {
        rigidBody.constraints = RigidbodyConstraints.None;
    }

    public void TouchFloorBlender()
    {
        if (soundFall != null)
        {
            ManagerAudio.Instance.PlaySound(soundFall);
        }
        else
        {
            Debug.Log($"<color=red>Не добавил аудио клип в объект {gameObject.name}</color>");
        }
    }

    /// <summary>
    /// Ускорение скорости через drag
    /// </summary>
    public void BoostSpeed()
    {
        rigidBody.drag = .5f;
    }

    /// <summary>
    /// Удалить Fruit
    /// </summary>
    public void DestoyMe()
    {
        Destroy(gameObject);
    }
}
