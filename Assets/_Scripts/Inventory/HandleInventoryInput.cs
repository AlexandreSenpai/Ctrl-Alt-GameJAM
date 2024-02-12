using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInventoryInput : MonoBehaviour
{
    InventoryController controller;
    void Start()
    {
        this.controller = GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(this.controller.DropItemKey)) {
            this.controller.DropItem();
        }
    }
}
