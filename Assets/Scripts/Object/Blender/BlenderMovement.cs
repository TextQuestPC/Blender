using UnityEngine;

public class BlenderMovement : ObjectMovement
{
    public delegate void EndMove();
    public event EndMove AfterEndMove;

    [SerializeField] private float[] positions;
    [SerializeField] private BlenderAnimation blenderAnimation;

    private int numberCurrentLine;

    public void MoveToLine(int numberLine)
    {
        numberCurrentLine = numberLine;
        SetNextPosition();
    }

    public void MoveToLineBeside(bool right)
    {
        if (right)
        {
            if(numberCurrentLine < positions.Length - 1)
            {
                numberCurrentLine++;
                blenderAnimation.SwipeRight();
            }
            else
            {
                return;
            }
        }
        else
        {
            if(numberCurrentLine > 0)
            {
                numberCurrentLine--;
                blenderAnimation.SwipeLeft();
            }
            else
            {
                return;
            }
        }

        SetNextPosition();
    }

    private void SetNextPosition()
    {
        Vector3 newPos = transform.position;
        newPos.x = positions[numberCurrentLine];
        nextPos = newPos;
        canMove = true;
    }

    protected override void AfterMove()
    {
        blenderAnimation.StopSwipe();
        AfterEndMove?.Invoke();
    }
}
