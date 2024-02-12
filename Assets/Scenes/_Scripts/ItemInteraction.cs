using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : Interaction<Item> {

    public void UnactivateItem(Item item) {
        if(item == null) return;
        item.Unactivate();
    }

    void Update() {

        if(!this.PlayerIsClose()) return;

        this.ShowLabelIfEntityIsClose();

        if(this.Interacted()) {
            this.events.Invoke(this.transform.GetComponent<Item>());
        }
        
    }
}