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
        GameManager gm = Object.FindAnyObjectByType<GameManager>();

        if (gm != null)
        {
            // GameManager'daki listeye bakıyoruz
            if (!gm.toplananIDler.Contains(itemID))
            {
                if (ses != null)
                {
                    AudioSource.PlayClipAtPoint(ses.clip, transform.position);
                }

                gm.ObjectCollected(itemID); 
                Destroy(gameObject);
            }
            else
            {
                // Zaten alındıysa puan vermeden yok et
                Destroy(gameObject);
            }
        }
    }
}