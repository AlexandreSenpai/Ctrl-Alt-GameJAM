using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interaction<T> : MonoBehaviour
{
    protected string interactionText = "Aperte 'E' para interagir";
    [SerializeField] public byte distanceToInteract;
    [SerializeField] public UnityEvent<T> events;
    protected Transform player;
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
}