using UnityEngine;
using System.Collections;

public class CocukKurtarici : MonoBehaviour
{
    public float yaklasmaMesafesi = 3f; 
    public GameObject parlamaEfekti;    
    public AudioSource kurtarmaSesi;   
    private bool kurtarildi = false;

    void Update()
    {
        if (kurtarildi) return;

        // Oyuncu etiketini kontrol et (Hata vermemesi için)
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        float mesafe = Vector3.Distance(transform.position, player.transform.position);

        if (mesafe <= yaklasmaMesafesi)
        {
            StartCoroutine(KurtarmaSureci());
        }
    }

    IEnumerator KurtarmaSureci()
    {
        kurtarildi = true;

        // 1. Işığı/Efekti Yak (Kodun en başında yapıyoruz ki hemen görünsün)
        if (parlamaEfekti != null) 
        {
            parlamaEfekti.SetActive(true);
            
            // Işık çok sönükse diye şiddetini kodla artırıyoruz
            Light isik = parlamaEfekti.GetComponent<Light>();
            if (isik != null) isik.intensity = 50f; 
        }

        // 2. Ses Çıkar
        if (kurtarmaSesi != null) kurtarmaSesi.Play();

        // 3. Ekranda Yazı Yaz
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.StartCoroutine(gm.ShowBriefMessage("Çocuğu Kurtardın!"));
        }

        // 4. Süzülme Efekti
        float sayac = 0;
        while (sayac < 1.5f) // Biraz daha uzun süzülsün
        {
            transform.Translate(Vector3.up * Time.deltaTime * 1.5f);
            sayac += Time.deltaTime;
            yield return null;
        }

        // 5. Çocuğu Kaybet
        gameObject.SetActive(false); 
    }
}