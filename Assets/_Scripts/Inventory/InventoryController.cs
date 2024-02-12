using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{   

    [SerializeField]
    public KeyCode GetItemKey;
    [SerializeField]
    public KeyCode DropItemKey;
    Inventory inventory;

    void Start() {
        this.inventory = GetComponent<Inventory>();
    }

    public void AddToInventory(Item item) {
        this.inventory.AddItemNextEmptySlot(item);
    }

    public void DropItem() {
        Slot slot = this.inventory.GetSlot(this.inventory.currentSlot);
        
        if(slot.IsEmpty()) return;

        Item item = slot.GetItem();
        item.transform.position = this.transform.position;
        item.Activate();

        slot.RemoveItem();
    }

}
