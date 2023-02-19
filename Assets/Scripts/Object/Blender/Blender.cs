using UnityEngine;

[RequireComponent(typeof(BlenderMovement))]
public class Blender : MonoBehaviour
{
    [SerializeField] private BlenderAnimation blenderAnimation;
    [SerializeField] private AudioClip[] soundBlender;
    private int countSound = 0;

    private int numberLine = 0;
    private int numberNextLine;
    public int GetNumberLine { get => numberLine; }

    private BlenderMovement movement;
    private BlenderFloorCollision collision;

    private void Start()
    {
        movement = GetComponent<BlenderMovement>();

        ManagerSwipeTap.Instance.Tap += MoveToLine;
        ManagerSwipeTap.Instance.Swipe += MoveToLineBeside;
    }

    /// <summary>
    /// Заморозка Блендер на текущей позиции
    /// </summary>
    public void Freeze()
    {
    }

    public void EndFreeze()
    {
        blenderAnimation.Work();
    }

    private void MoveToLine(int numberLine)
    {
        ManagerAudio.Instance.PlaySound(soundBlender[ChangeClipSound()]);

        numberNextLine = numberLine;
        movement.AfterEndMove += ChangeNumberLine;
        movement.MoveToLine(numberLine);
    }

    private void MoveToLineBeside(bool right)
    {
        ManagerAudio.Instance.PlaySound(soundBlender[ChangeClipSound()]);

        movement.MoveToLineBeside(right);
    }

    private int ChangeClipSound()
    {
        countSound++;

        if (countSound >= soundBlender.Length)
            countSound = 0;

        return countSound;
    }

    private void ChangeNumberLine()
    {
        movement.AfterEndMove -= ChangeNumberLine;
        numberLine = numberNextLine;
    }
}
