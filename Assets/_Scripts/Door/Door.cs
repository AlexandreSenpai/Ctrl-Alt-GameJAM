using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Dialog))]
public class Door : MonoBehaviour {
    [SerializeField] UnityEvent events;
    [SerializeField] private GameObject possessionRequired;
    private Transform player;
    private Possession possession;
    private float distanceToPlayer;
    private float distanceToInteract = 2f;
    private Dialog dialog;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        possession = player.GetComponent<Possession>();
        dialog = GetComponent<Dialog>();
    }

    private void Update() {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < distanceToInteract && Input.GetButtonDown("Interact Key")) {
            if (possession.GetCurrentPossession() == possessionRequired) {
                events.Invoke();
                return;
            }
            dialog.StartSpeech();
        }
    } 
}
