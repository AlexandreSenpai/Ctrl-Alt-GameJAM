using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Unactivate() {
        this.transform.gameObject.SetActive(false);
        ItemInteraction interactionLabel = GetComponent<ItemInteraction>();
        Label label = interactionLabel.GetLabel();
        label.UpdateLabelText(null);
        label.Unactivate();
    }

    public void Activate() {
        ItemInteraction interactionLabel = GetComponent<ItemInteraction>();
        Label label = interactionLabel.GetLabel();
        label.Activate();
        this.transform.gameObject.SetActive(true);
    }

}
