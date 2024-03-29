using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Label : MonoBehaviour {
    private string text;
    private Transform parent;
    private GameObject UI;
    private GameObject labelGUI;
    private TextMeshProUGUI textMeshPro;
    
    void Start() {
        this.UI = GameObject.FindGameObjectWithTag("UI");
        
        if(this.UI == null) {
            Debug.LogError("Could not find any object with 'UI' Tag");
            return;
        }

        if(this.transform.parent == null) {
            Debug.LogError("Could not find any parent relative to this Label");
            return;
        }

        this.parent = this.transform.parent;
        this.AttachTextMeshComponentToParent();
    }

    private void AttachTextMeshComponentToParent() {
        GameObject textGUI = new GameObject($"{this.parent.name} - label");
        
        this.labelGUI = textGUI;

        TextMeshProUGUI meshPro = textGUI.AddComponent<TextMeshProUGUI>();
        
        meshPro.fontSize = 24;
        meshPro.alignment = TextAlignmentOptions.Center;
        meshPro.color = Color.white;

        this.textMeshPro = meshPro;

        textGUI.transform.SetParent(this.UI.transform, false);

        RectTransform rectTransform = textGUI.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = this.parent.transform.position;
        rectTransform.sizeDelta = new Vector2(200, 50);
    }

    public bool FollowPosition(Vector2 worldPosition) {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return false;

        float objectHeight = parent.GetComponentInChildren<SpriteRenderer>().bounds.size.y + .2f;
        Vector3 adjustedPosition = worldPosition + new Vector2(0, objectHeight);

        Vector2 viewportPosition = mainCamera.WorldToViewportPoint(adjustedPosition);
        RectTransform canvasRectTransform = UI.GetComponent<RectTransform>();

        Vector2 worldObjectScreenPosition = new Vector2(
        ((viewportPosition.x * canvasRectTransform.sizeDelta.x) - (canvasRectTransform.sizeDelta.x * 0.5f)),
        ((viewportPosition.y * canvasRectTransform.sizeDelta.y) - (canvasRectTransform.sizeDelta.y * 0.5f)));

        labelGUI.GetComponent<RectTransform>().anchoredPosition = worldObjectScreenPosition;
        return true;
    }

    public void Unactivate() {
        this.labelGUI.SetActive(false);
    }

    public void Activate() {
        this.labelGUI.SetActive(true);
    }

    public void UpdateLabelText(string newText) {
        if(newText == "" || newText?.Length > 50) return;
        this.text = newText;
        this.textMeshPro.text = this.text;
    }

    void Update() {
        if(parent == null) return;
        this.FollowPosition(this.parent.position);
    }

    public void ShowLabelIfEntityIsClose(GameObject entity, string label, float distance) {        
        if(entity == null) return;
        
        if (!EntityIsClose(entity, distance)) {
            UpdateLabelText(null);
            return;
        }

        UpdateLabelText(label);
    }

    public bool EntityIsClose(GameObject entity, float distance) {
        if (Vector2.Distance(entity.transform.position, transform.position) > distance) {
            UpdateLabelText(null);
            return false;
        }
        return true;
    }
    
}
