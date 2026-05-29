using UnityEngine;

public class CounterMaterialSwap : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private int currentMaterialIndex = 0;

    private void Awake()
    {
        ApplyMaterial();
    }

    private void ApplyMaterial()
    {
        objectRenderer.sharedMaterial = materials[currentMaterialIndex];
    }
    
    
}
