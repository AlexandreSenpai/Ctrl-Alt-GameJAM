using UnityEngine;

public class ItemInteraction : Interaction<Item> {
    void Update() {

        this.GetLabel().ShowLabelIfEntityIsClose(player.gameObject, interactionText, distanceToInteract);
        if(this.Interacted()) {
            this.events.Invoke(this.transform.GetComponent<Item>());
        }
        
    }
}
public class DoorInteraction : Interaction<Label> {
    void Update() {

        this.GetLabel().ShowLabelIfEntityIsClose(player.gameObject, interactionText, distanceToInteract);
        if(this.Interacted()) {
            this.events.Invoke(this.transform.GetComponent<Label>());
        }
        
    }
}