using UnityEngine;

public class VisibilityTest : MonoBehaviour
{
    [SerializeField] VariableTest vt;

    private void Start()
    {
        if(vt != null)
        {
            Debug.Log($"{vt.shopIndex}");
        }
        
        vt.SetShopIndexValue(3);
    }
}
