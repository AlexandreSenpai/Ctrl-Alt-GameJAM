using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{   
    private Inventory inventory;

    void Start() {
        this.inventory = GetComponent<Inventory>();
    }

    public void AddToInventory(Item item) {
        this.inventory.AddItemNextEmptySlot(item);
    }

    public void DropItem() {
        this.inventory.DropItem();
    }

}
