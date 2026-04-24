using UnityEngine;
using TMPro;

public class iyiBuyucuDiyalog : MonoBehaviour
{
    public TextMeshProUGUI diyalogMetni;
    [TextArea(3, 10)]
    public string mesaj = "Elenor güçlenmek için çocukları kaçırıp kapıların ardına hapsetti. Lütfen onları kurtar!";

    void Start()
    {
        // Oyun başında yazı kutusunu tamamen gizle
        if (diyalogMetni != null)
        {
            diyalogMetni.gameObject.SetActive(false);
            diyalogMetni.text = ""; // İçini de boşaltalım garanti olsun
        }
    }

    // Yeşil kutunun içine girince çalışır
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            diyalogMetni.gameObject.SetActive(true); // Kutuyu aç
            diyalogMetni.text = mesaj; // Mesajı yaz
        }
    }

    // Yeşil kutunun dışına çıkınca çalışır
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            diyalogMetni.text = ""; // Önce metni sil
            diyalogMetni.gameObject.SetActive(false); // Sonra kutuyu kapat
        }
    }
}