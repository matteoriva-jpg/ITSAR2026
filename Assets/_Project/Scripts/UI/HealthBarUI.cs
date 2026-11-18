using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Image barFill;
    [SerializeField] TMP_Text healthValueText;
    Health myHealth;
    

    private void Awake()
    {
        Health myHealth = GetComponent<Health>();
        
    }
    private void OnEnable()
    {
        if (myHealth == null) myHealth = Health.PlayerHealth;
        myHealth.HealthChanged += UpdateBarValues;
    }

    private void OnDisable()
    {
        myHealth.HealthChanged -= UpdateBarValues;
    }
    void UpdateBarValues(float currHp, float maxHp)
    {
        barFill.fillAmount = currHp / maxHp;
        healthValueText.text = $"{Mathf.Round(currHp)}/ {Mathf.Round(maxHp)}";
    }
}
