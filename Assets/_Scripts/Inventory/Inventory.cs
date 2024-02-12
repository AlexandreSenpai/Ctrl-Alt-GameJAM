using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Slot {
    private Item item = null;

    public bool IsEmpty() {
        return this.item == null;
    }

    public void AddItem(Item item) {
        this.item = item;
    }

    public Item GetItem() {
        return this.item;
    }

    public void RemoveItem() {
        this.item = null;
    }
}

public class Inventory : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();
    public int currentSlot = 0;

    void Start() {
        for(int i = 1; i <= 8; i++) {
            this.slots.Add(new Slot());
        }
    }

    public Slot FirstSlot() {
        return this.slots.First();
    }

    public Slot LastSlot() {
        return this.slots.Last();
    }

    public Slot GetSlot(int index) {
        return this.slots[index];
    }

    public void AddItemNextEmptySlot(Item item) {

        bool added = false;

        foreach(Slot slot in this.slots) {
            if(!slot.IsEmpty()) continue;

            slot.AddItem(item);
            added = true;
            break;
        }

        if(!added) {
            Debug.LogWarning("There's no empty slot available to add this item");
            return;
        }
  
        Debug.Log($"Added {item.name} to the slot!");

    }

}
