using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanBari : MonoBehaviour
{
    public Slider healthSlider;
    private float MevcutCan;
    public float maxCan = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxCan;
        }
        MevcutCan = maxCan;
        UpdateUI();
    }

    public void HasarAlma(float miktar)
    {
        MevcutCan -= miktar; // Önce hasarı düşüyoruz
        
        // Canın eksiye düşmesini engelliyoruz ama 0'a ulaşmasına izin veriyoruz
        MevcutCan = Mathf.Clamp(MevcutCan, 0, maxCan); 
        
        UpdateUI(); // Barı güncelliyoruz

        Debug.Log("Kalan Can: " + MevcutCan); // Konsoldan takip etmen için

        if (MevcutCan <= 0)
        {
            Die();
        }
    }

   void Die()
{
    Debug.Log("Öldün! Yeniden başlatılıyor...");
    // Mevcut sahneyi (Level) ismine göre tekrar yükler
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
    
    void UpdateUI() //barın azalması
    {
        healthSlider.value = MevcutCan;
    }
    
}
