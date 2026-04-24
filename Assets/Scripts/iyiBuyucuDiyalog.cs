using UnityEngine;
using TMPro;

public class iyiBuyucuDiyalog : MonoBehaviour
{
    public Transform karakter;
    public TextMeshProUGUI diyalogMetni;
    public float konusmaMesafesi = 5f;
    private bool konusmaYapildi = false;

    void Start()
    {
        // Oyun başında yazı mutlaka kapalı olsun
        if (diyalogMetni != null)
        {
            diyalogMetni.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (karakter != null && diyalogMetni != null && !konusmaYapildi)
        {
            float mesafe = Vector3.Distance(transform.position, karakter.position);

            if (mesafe <= konusmaMesafesi)
            {
                Konus();
            }
        }
    }

    void Konus()
    {
        diyalogMetni.gameObject.SetActive(true); // Yazıyı görünür yapar
        diyalogMetni.text = "Elenor gençleşmek için çocukları kaçırıp kapıların ardına hapsetti. Lütfen onları kurtar!";
        konusmaYapildi = true;
        Debug.Log("Diyalog ekrana basıldı!");
    }
}