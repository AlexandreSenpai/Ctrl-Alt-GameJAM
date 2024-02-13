using System.Collections.Generic;
using UnityEngine;

public enum MoveStatus
{
    BLOCKED,
    COMPLETED,
    ONGOING
}

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private bool humanControlling = false;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private LayerMask wallLayer;

    private Vector2 targetPosition;

    public void TakeControl() {
        humanControlling = true;
    }

    public bool IsBeingControlledByHuman() {
        return humanControlling;
    }

    private Vector2 GetEntitySpriteSize() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        return new Vector2(spriteSize.x * transform.localScale.x, spriteSize.y * transform.localScale.y);
    }

    private MoveStatus TranslateTo(Vector2 movement) {
        Vector2 nextPosition = transform.position + (Vector3)movement * this.speed;
        if (Physics2D.OverlapBox(nextPosition, this.GetEntitySpriteSize(), 0f, wallLayer) && !this.gameObject.CompareTag("Player")) return MoveStatus.BLOCKED;
        transform.position = nextPosition;
        return MoveStatus.COMPLETED;
    }
    private MoveStatus MoveTo(Vector2 position) {
        Vector2 currentPos = transform.position;

        Vector2 directionToTarget = (position - currentPos).normalized;

        float distanceToTarget = Vector2.Distance(currentPos, position);

        Debug.DrawRay(currentPos, directionToTarget * distanceToTarget, Color.cyan, 2f);

        Vector2 nextPosition = Vector2.MoveTowards(currentPos, position, this.speed * Time.deltaTime);

        if (Physics2D.OverlapBox(nextPosition, this.GetEntitySpriteSize(), 0f, wallLayer)) {
            Debug.DrawRay(currentPos, directionToTarget * distanceToTarget, Color.red, 2f);
            return MoveStatus.BLOCKED;
        }
        
        this.transform.position = nextPosition;

        if(Vector2.Distance(currentPos, position) > .2f) return MoveStatus.ONGOING;

        Debug.DrawRay(currentPos, directionToTarget * distanceToTarget, Color.green, 2f);
        return MoveStatus.COMPLETED;
    }

    
    public MoveStatus Move(Vector2 movement) {
        if (humanControlling) {
            return TranslateTo(movement);
        } else {
            return MoveTo(movement);
        }
    }

}