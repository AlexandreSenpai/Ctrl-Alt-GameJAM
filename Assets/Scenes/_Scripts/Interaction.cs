using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] public string interactionText;
    [SerializeField] public KeyCode interactionKey;
    [SerializeField] public byte distanceToInteract;
    [SerializeField] public UnityEvent events;
    private Transform player;
    private Label label;

    void Start() {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj == null) {
            Debug.LogError("Could not find any object with 'Player' Tag");
            return;
        }

        this.player = playerObj.transform;
        
        GameObject labelObject = new GameObject("Label");
        labelObject.AddComponent<Label>();
        labelObject.transform.SetParent(this.transform);

        this.label = labelObject.GetComponent<Label>();
    }

    void Update() {

        if(this.player == null) return;
        
        if (Vector2.Distance(player.position, transform.position) > distanceToInteract) {
            this.label.SetLabelText(null);
            return;
        }

        this.label.SetLabelText(this.interactionText);

        if (Input.GetKeyDown(this.interactionKey)) {
            // Chama os eventos registrados na lista de eventos
            if(events == null) return; 
            events.Invoke();
        }
    }
}
