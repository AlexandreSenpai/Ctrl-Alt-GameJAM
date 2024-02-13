using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform currentTarget;
    
    private void Update() {
        Vector3 cameraPos = new Vector3(currentTarget.position.x, currentTarget.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, cameraPos, 0.05f);
    }

    public void SetTarget(Transform newTarget) {
        if (newTarget == currentTarget) return;
        currentTarget = newTarget; 
    }
}
