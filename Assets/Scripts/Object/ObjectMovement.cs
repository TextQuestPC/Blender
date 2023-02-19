using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    protected Vector3 nextPos;
    protected bool canMove = false;

    private void Update()
    {
        if (canMove)
            MoveObject();
    }

    protected virtual void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * moveSpeed);

        if (transform.position == nextPos)
        {
            canMove = false;
            AfterMove();
        }
    }

    protected virtual void AfterMove()
    {

    }
}
