using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] UnityEvent events;
    Transform player;
    TMP_Text UIText;

    byte distanceToInteract = 2; 
    float distanceToPlayer;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        UIText = GameObject.FindWithTag("InteractionTextUI").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);  
        if (distanceToPlayer > distanceToInteract) {
            UIText.text = null;
            return;
        }
        UIText.text = "E para Interagir";
        if (Input.GetKeyDown("e")) {
            // Chama os eventos registrados na lista de eventos
            events.Invoke();
        }
    }
}
