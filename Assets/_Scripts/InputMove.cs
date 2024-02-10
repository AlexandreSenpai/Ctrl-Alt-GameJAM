using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;

    private bool canMove = true;

    void Start() {
        
    }

    public void setCanMove(bool canMove) {
        if(this.canMove != canMove) this.canMove = canMove;
    }

    void Move() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        this.transform.Translate(movement * speed * Time.deltaTime);
    }

    void Update() {
        this.Move();
    }
}
