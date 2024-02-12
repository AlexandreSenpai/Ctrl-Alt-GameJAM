using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Interaction<T> : MonoBehaviour
{
    [SerializeField] public string interactionText;
    [SerializeField] public KeyCode interactionKey;
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
        if (Input.GetKeyDown(this.interactionKey)) return true;
        return false;
    }

    public void ShowLabelIfEntityIsClose() {        
        if(this.player == null) return;
        
        if (Vector2.Distance(player.position, transform.position) > distanceToInteract || this.label.gameObject.activeSelf == false) {
            this.label.SetLabelText(null);
            return;
        }

        this.label.SetLabelText(this.interactionText);
    }
}