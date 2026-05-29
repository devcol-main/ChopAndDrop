using UnityEngine;

[ RequireComponent(typeof(ClearCounter))]
[ RequireComponent(typeof(CounterMaterialSwap))]
public class SelectedCounterVisual : MonoBehaviour
{
    private ClearCounter clearCounter;
    private CounterMaterialSwap counterMaterialSwap;
    
    void Start()
    {
        clearCounter = GetComponent<ClearCounter>();
        counterMaterialSwap = GetComponent<CounterMaterialSwap>();
        
        Player.Instance.PlayerController.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;

    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == clearCounter)
        {
            Selected();
        }
        else
        {
            Unselected();
        }
    }

    private void Selected()
    {
        counterMaterialSwap.SetSeletectedMaterial();
    }
    
    private void Unselected()
    {
        counterMaterialSwap.SetOriginalMaterial();
    }

}
