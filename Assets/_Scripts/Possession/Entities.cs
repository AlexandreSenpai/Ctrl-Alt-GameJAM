using UnityEngine;

public class Entities : MonoBehaviour {
    private float distanceToPlayer;
    private Transform player;
    private Possession possession;
    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        possession = player.GetComponent<Possession>();
    }

    private void Update() {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceToPlayer < 5f) {
            possession.AddToViewList(transform);
        } else {
            possession.RemoveFromViewList(transform);
        }
    }
}