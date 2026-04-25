using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CezaKapisi : MonoBehaviour
{
    public int gerekenNesne = 3;
    public string kasabaSahneAdi = "SampleScene"; // Buraya kasaba sahnenin adını yaz
    public AudioSource cikisMuzigi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 4. ADIM: Kapı, hafızadaki (PlayerPrefs) güncel sayıyı kontrol ediyor.
            int miktar = PlayerPrefs.GetInt("CezaNesnesi", 0);
            GameManager gm = FindObjectOfType<GameManager>();

            if (miktar >= gerekenNesne)
            {
                StartCoroutine(BasariVeIsinlanma());
            }
            else
            {
                int eksik = gerekenNesne - miktar;
                if(gm != null) gm.StartCoroutine(gm.ShowBriefMessage("Bu mühürlü bir kapı! " + eksik + " nesne daha bulmalısın."));
            }
        }
    }

    IEnumerator BasariVeIsinlanma()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if(gm != null) gm.StartCoroutine(gm.ShowBriefMessage("Başardın! Kasabaya dönüyorsun!"));
        
        if (cikisMuzigi != null) cikisMuzigi.Play();
        
        yield return new WaitForSeconds(2.5f);

        // 5. ADIM: Kasabaya giderken hafızayı temizliyoruz ki bir dahaki oyunda 0'dan başlasın.
        PlayerPrefs.DeleteKey("CezaNesnesi");
        SceneManager.LoadScene("SampleScene");
    }
}