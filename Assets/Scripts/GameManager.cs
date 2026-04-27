using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI bilgiMetni;
    public int toplananCezaNesnesi;

    // Statik liste: Sahne değişse de kimlikleri burada tutar
    public static List<string> toplananIDler = new List<string>();

    void Start()
    {
        // 1. ADIM: Hafızadaki sayıyı al
        toplananCezaNesnesi = PlayerPrefs.GetInt("CezaNesnesi", 0);
        
        // KRİTİK DÜZELTME: Eğer hafızada sayı 0 ise (oyun yeni başladıysa veya sıfırlandıysa)
        // listeyi de temizle ki eski ID'ler kalmasın.
        if (toplananCezaNesnesi == 0)
        {
            toplananIDler.Clear();
        }

        if (bilgiMetni != null)
        {
            bilgiMetni.text = "";
            bilgiMetni.gameObject.SetActive(false);
        }
    }

    public void ObjectCollected(string id)
    {
        // 2. ADIM: Bu ID daha önce alınmış mı kontrol et
        if (!toplananIDler.Contains(id))
        {
            // 3. ADIM: Listeye ekle ve sayıyı artır
            toplananIDler.Add(id);
            toplananCezaNesnesi++;

            // 4. ADIM: Hafızaya (PlayerPrefs) kaydet ve zorla yazdır (Save)
            PlayerPrefs.SetInt("CezaNesnesi", toplananCezaNesnesi);
            PlayerPrefs.Save(); 
            
            // 5. ADIM: Ekranda mesajı göster
            StopAllCoroutines();
            StartCoroutine(ShowBriefMessage(toplananCezaNesnesi + " / 3 nesne toplandı!"));

            Debug.Log("Başarıyla toplandı: " + id + " | Toplam Sayı: " + toplananCezaNesnesi);
        }
        else
        {
            // Eğer buraya girerse, aynı nesneyi tekrar aldın demektir
            Debug.LogWarning(id + " zaten toplanmış! Puan verilmiyor.");
        }
    }

    public IEnumerator ShowBriefMessage(string message)
    {
        if (bilgiMetni != null)
        {
            bilgiMetni.text = message;
            bilgiMetni.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            bilgiMetni.gameObject.SetActive(false);
        }
    }

    // TEST İÇİN YARDIMCI FONKSİYON: Yanınca veya oyunu sıfırlayınca bunu çağırabilirsin
    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteAll();
        toplananIDler.Clear();
        toplananCezaNesnesi = 0;
    }
}