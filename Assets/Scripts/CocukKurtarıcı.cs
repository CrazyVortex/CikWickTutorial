using UnityEngine;
using System.Collections;

public class CocukKurtarici : MonoBehaviour
{
    [Header("Mesafe ve Görsel")]
    public float yaklasmaMesafesi = 3f; 
    public GameObject parlamaEfekti;    
    public AudioSource kurtarmaSesi;   
    
    [Header("Gorev Ayari")]
    public string cocukID; // Inspector'dan: ChildMavi, ChildKirmizi vb.

    private bool kurtarildi = false;

    void Update()
    {
        if (kurtarildi) return;

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

        if (parlamaEfekti != null) parlamaEfekti.SetActive(false);
        if (kurtarmaSesi != null) kurtarmaSesi.Play();

        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            // Statik listede yoksa (ilk defa kurtarılıyorsa)
            if (!GameManager.toplananIDler.Contains(cocukID))
            {
                GameManager.toplananIDler.Add(cocukID);
                
                // Çocuk hafızasını güncelle
                int mevcutCocuk = PlayerPrefs.GetInt("KurtarilanCocuk", 0);
                mevcutCocuk++;
                PlayerPrefs.SetInt("KurtarilanCocuk", mevcutCocuk);
                PlayerPrefs.Save();

                gm.StopAllCoroutines();
                gm.StartCoroutine(gm.ShowBriefMessage("Çocuk Kurtarıldı!"));
            }
        }

        // Süzülme animasyonu
        float sayac = 0;
        while (sayac < 1.5f) 
        {
            transform.Translate(Vector3.up * Time.deltaTime * 1.5f);
            sayac += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false); 
    }
}