using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatopPrefab;
    [SerializeField] private Transform topPoint;
    
    public void Interect()
    {
        Debug.Log("Clear Counter Interact");
        
        Transform objectTransform = Instantiate(tomatopPrefab, topPoint);
        
        objectTransform.transform.localPosition = Vector3.zero;
        
    }
}
