using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{    
    [SerializeField] LayerMask entitiesMask;
    [SerializeField] bool isPossessing;
    [SerializeField] GameObject currentPossessing;
    [SerializeField] Transform currentTarget;
    [SerializeField] List<Transform> entitiesList;
    float currentTargetDistanceToPlayer;
    [SerializeField] FollowCamera followCamera;
    [SerializeField] MoveController moveController;

    private void Start() {
        moveController = GetComponent<MoveController>();
    }

    private void Update() {
       currentTargetDistanceToPlayer = currentTarget!=null ? Vector2.Distance(transform.position, currentTarget.transform.position): 10f;

        foreach (Transform entity in entitiesList) {
            float entityDistance = Vector2.Distance(transform.position, entity.position);
            if (entityDistance < currentTargetDistanceToPlayer) {
                SetTarget(entity);
            }
        }

        if (!isPossessing && currentTarget != null && Input.GetKeyDown("r")) {
            followCamera.SetTarget(currentTarget);
            isPossessing = true;
            currentPossessing = currentTarget.gameObject;
            GetComponent<SpriteRenderer>().enabled = false;
            currentTarget.GetComponent<MoveController>().TakeControl();
        }

        if (currentTarget!= null && currentTarget.GetComponent<MoveController>().IsBeingControlledByHuman() && Input.GetKeyDown("f")) {
            transform.position = currentTarget.transform.position;
            isPossessing = false;
            currentPossessing = null;
            currentTarget.GetComponent<MoveController>().ReleaseControl();
            followCamera.SetTarget(transform);
            GetComponent<SpriteRenderer>().enabled = true;
            moveController.TakeControl();
        }
    }
    
    private void SetTarget(Transform newTarget) {
        currentTarget = newTarget;
    }

    #region PUBLIC METHODS 
    public GameObject GetCurrentPossession() {
        return currentPossessing;
    }
    
    public void RemoveFromViewList(Transform removedTarget) {
        entitiesList.Remove(removedTarget);
    }
    
    public void AddToViewList(Transform newTarget) {
        if (entitiesList.Contains(newTarget)) return;
        entitiesList.Add(newTarget);
    }
    #endregion
}
