using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioSource ses;
    [Header("Kimlik Ayarı")]
    public string itemID; // Inspector'dan her nesneye farklı isim ver (Mavi1, Mavi2 gibi)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        // ÖNEMLİ: Statik listeye gm.toplananIDler yerine doğrudan GameManager.toplananIDler ile erişiyoruz
        if (!GameManager.toplananIDler.Contains(itemID))
        {
            if (ses != null)
            {
                AudioSource.PlayClipAtPoint(ses.clip, transform.position);
            }

            // GameManager fonksiyonunu çağırmak için sahnede GameManager'ı buluyoruz
            GameManager gm = Object.FindAnyObjectByType<GameManager>();
            if (gm != null)
            {
                gm.ObjectCollected(itemID);
            }

            Destroy(gameObject);
        }
        else
        {
            // Eğer bu ID zaten listede varsa, sadece nesneyi sil (sayacı artırma)
            Destroy(gameObject);
        }
    }
}