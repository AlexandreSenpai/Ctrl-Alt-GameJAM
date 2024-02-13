using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
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

    void Start() {
        this.slots.Add(new Slot());
    }

    public Slot GetSlot() {
        return this.slots.First();
    }

    private void UpdateItemPosition(Item item, Vector2 position) {
        item.transform.position = position;
    }

    public bool DropItem() {
        Slot slot = this.GetSlot();
        
        if(slot.IsEmpty()) return false;

        Item item = slot.GetItem();
        this.UpdateItemPosition(item, this.transform.position);
        slot.RemoveItem();
        item.Activate();
        
        return true;
    } 

    public bool AddItemNextEmptySlot(Item item) {

        bool added = false;

        foreach(Slot slot in this.slots) {
            if(!slot.IsEmpty()) continue;

            slot.AddItem(item);
            added = true;
            break;
        }

        if(!added) {
            Debug.LogWarning("There's no empty slot available to add this item");
            return added;
        }
  
        item.Unactivate();
        Debug.Log($"Added {item.name} to the slot!");
        return added;
    }

}
