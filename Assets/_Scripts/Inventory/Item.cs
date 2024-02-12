using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public void Unactivate() {
        this.transform.gameObject.SetActive(false);
        ItemInteraction interactionLabel = GetComponent<ItemInteraction>();
        Label label = interactionLabel.GetLabel();
        label.Unactivate();
    }

    public void Activate() {
        this.transform.gameObject.SetActive(true);
        ItemInteraction interactionLabel = GetComponent<ItemInteraction>();
        Label label = interactionLabel.GetLabel();
        label.Activate();
    }

}
