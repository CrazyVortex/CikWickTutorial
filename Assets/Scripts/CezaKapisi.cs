using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CezaKapisi : MonoBehaviour
{
    [Header("Gereksinimler")]
    public int gerekenNesne = 3; // Toplam 3 nesne lazım
    public int gerekenCocuk = 3; // Toplam 3 çocuk lazım

    [Header("Sahne ve Ses")]
    public string kasabaSahneAdi = "SampleScene"; 
    public AudioSource cikisMuzigi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hafızadaki güncel skorları çekiyoruz
            int toplananNesne = PlayerPrefs.GetInt("CezaNesnesi", 0);
            int kurtarilanCocuk = PlayerPrefs.GetInt("KurtarilanCocuk", 0);
            
            GameManager gm = FindObjectOfType<GameManager>();

            // Eğer hem nesneler hem çocuklar tamamsa (3 ve 3)
            if (toplananNesne >= gerekenNesne && kurtarilanCocuk >= gerekenCocuk)
            {
                StartCoroutine(BasariVeIsinlanma());
            }
            else
            {
                int eksikNesne = gerekenNesne - toplananNesne;
                int eksikCocuk = gerekenCocuk - kurtarilanCocuk;
                
                string mesaj = "Bu mühürlü bir kapı! ";
                
                // Mesaj kurgusunu senin istediğin "ve" bağlacına göre düzelttim
                if (eksikNesne > 0 && eksikCocuk > 0)
                {
                    mesaj += eksikNesne + " nesne ve " + eksikCocuk + " çocuk daha bulmalısın.";
                }
                else if (eksikNesne > 0)
                {
                    mesaj += eksikNesne + " nesne daha bulmalısın.";
                }
                else if (eksikCocuk > 0)
                {
                    mesaj += eksikCocuk + " çocuk daha kurtarmalısın.";
                }

                if(gm != null) 
                {
                    gm.StopAllCoroutines();
                    gm.StartCoroutine(gm.ShowBriefMessage(mesaj));
                }
            }
        }
    }

    IEnumerator BasariVeIsinlanma()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if(gm != null) 
        {
            gm.StopAllCoroutines();
            gm.StartCoroutine(gm.ShowBriefMessage("Mühür çözüldü! Kasabaya dönüyorsun!"));
        }
        
        if (cikisMuzigi != null) cikisMuzigi.Play();
        
        yield return new WaitForSeconds(2.5f);

        // Kasabaya dönerken her şeyi tertemiz yapıyoruz
        PlayerPrefs.DeleteKey("CezaNesnesi");
        PlayerPrefs.DeleteKey("KurtarilanCocuk");
        GameManager.toplananIDler.Clear();
        
        SceneManager.LoadScene(kasabaSahneAdi);
    }
}