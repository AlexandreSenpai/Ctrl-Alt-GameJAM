using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour {

    void Start() {
        
    }
    void Move() {
        Move move = this.gameObject.GetComponent<Move>();
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        // move.MoveTo(Time.deltaTime * movement);
    }

    void Update() {
        this.Move();
    }
}
