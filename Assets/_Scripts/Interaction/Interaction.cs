using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interaction<T> : MonoBehaviour
{
    private string interactionText = "Aperte 'E' para interagir";
    [SerializeField] public byte distanceToInteract;
    [SerializeField] public UnityEvent<T> events;
    private Transform player;
    private Label label;

    void Start() {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj == null) {
            Debug.LogError("Could not find any object with 'Player' Tag");
            return;
        }

        this.player = playerObj.transform;
        this.InitializeLabel();
    }

    private void InitializeLabel() {
        GameObject labelObject = new GameObject("Label");
        labelObject.AddComponent<Label>();
        labelObject.transform.SetParent(this.transform);
        this.label = labelObject.GetComponent<Label>();
    }

    public Label GetLabel() {
        return this.label;
    }

    public bool Interacted() {
        if (Input.GetButtonDown("Interact Key")) return true;
        return false;
    }

    public bool PlayerIsClose() {
        if (Vector2.Distance(player.position, transform.position) > distanceToInteract) {
            this.label.UpdateLabelText(null);
            return false;
        }
        return true;
    }

    public void ShowLabelIfEntityIsClose() {        
        if(this.player == null) return;
        
        if (!this.PlayerIsClose() || this.label.gameObject.activeSelf == false) {
            this.label.UpdateLabelText(null);
            return;
        }

        this.label.UpdateLabelText(this.interactionText);
    }
}