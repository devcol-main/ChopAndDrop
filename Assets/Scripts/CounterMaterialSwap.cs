using UnityEngine;

public class CounterMaterialSwap : MonoBehaviour
{
    
    public enum MaterialType
    {
        ORIGINAL = 0,
        SECONDARY = 1,
        
    }
    
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private int currentMaterialIndex = 0;

    private void Awake()
    {
        ApplyMaterial();
    }

    public void SetMaterial(MaterialType materialType)
    {
        currentMaterialIndex = (int)materialType;
        ApplyMaterial();
    }
    
    public void SetOriginalMaterial()
    {
        currentMaterialIndex = (int)MaterialType.ORIGINAL;
        ApplyMaterial();
    }
    
    public void SetSeletectedMaterial()
    {
        currentMaterialIndex = (int)MaterialType.SECONDARY;
        ApplyMaterial();
    }

        
    
    public void SwitchToNextMaterial()
    {
        if (materials.Length == 0) return;

        // Increment index and loop back to 0 if we reach the end of the array
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        ApplyMaterial();
    }

    // Call this method to switch to the previous material
    public void SwitchToPreviousMaterial()
    {
        if (materials.Length == 0) return;

        currentMaterialIndex = (currentMaterialIndex - 1 + materials.Length) % materials.Length;
        ApplyMaterial();
    }
    
    

    private void ApplyMaterial()
    {
        objectRenderer.sharedMaterial = materials[currentMaterialIndex];
    }
    
    
}
