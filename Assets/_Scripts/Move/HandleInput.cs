using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour {

    private MoveController controller;

    void Start() {
        this.controller = this.gameObject.GetComponent<MoveController>();
    }

    void FixedUpdate() {
        if(this.controller != null && this.controller.IsBeingControlledByHuman()) {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
            this.controller.Move(Time.deltaTime * movement);
        }
    }

}
