using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum MoveStatus {
    BLOCKED,
    COMPLETED,
    ONGOING
}

public class MoveController : MonoBehaviour
{
    
    [SerializeField]
    public bool humanControlling = false;

    [SerializeField]
    public float speed = 5.0f;

    [SerializeField]
    private LayerMask wallLayer;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeControl() {
        this.humanControlling = true;
    }

    public bool IsBeingControlledByHuman() {
        return this.humanControlling;
    }

    public MoveStatus TranslateTo(Vector2 position) {
        this.transform.Translate(this.speed * position);
        return MoveStatus.COMPLETED;
    }

    public MoveStatus MoveTo(Vector2 position) {
         if (!CanMove(position)) return MoveStatus.BLOCKED;

        rb.MovePosition(Vector2.MoveTowards(rb.position, position, this.speed * 5 * Time.deltaTime));
        
        if(Vector2.Distance(rb.position, position) > 0.1f) return MoveStatus.ONGOING;

        return MoveStatus.COMPLETED;
    }

    private RaycastHit2D CreateRayCast(Vector2 direction) {
        return Physics2D.Raycast(rb.position, direction, .8f, wallLayer);
    }
    private void DrawFacingRayCast(Vector2 facingTo, Color color) {
        Debug.DrawRay(rb.position, facingTo, color);
    }

    private bool CanMove(Vector2 direction)
    {
        RaycastHit2D hit = this.CreateRayCast(direction);

        if (hit.collider != null)
        {
            this.DrawFacingRayCast(direction.normalized * hit.distance, Color.green);
            return false;
        }

        this.DrawFacingRayCast(direction.normalized * .8f, Color.red);
        return true;
    }

    public MoveStatus Move(Vector2 position) {

        if(!this.humanControlling) {
            return this.MoveTo(position);
        } else {
            return this.TranslateTo(position);
        }

    }
}
