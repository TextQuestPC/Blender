using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMy : MonoBehaviour
{
    [SerializeField] protected AudioClip soundButton;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickByButton);
    }

    private void ClickByButton()
    {
        if (soundButton != null)
        {
            ManagerAudio.Instance.PlaySound(soundButton);
        }
        else
        {
            Debug.Log($"<color=red>Не добавил аудио клип в кнопку {gameObject.name}!</color>");
        }

        OtherButtonAction();
    }

    protected virtual void OtherButtonAction()
    {

    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickByButton);
    }
}
