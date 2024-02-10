using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    public float speed = 500.0f;
    public void TranslateTo(Vector2 position) {
        this.transform.Translate(this.speed * position);
    }

    public void MoveTo(Vector2 position) {
        this.transform.position = Vector2.MoveTowards(this.transform.position, position, this.speed * Time.deltaTime);
    }

}
