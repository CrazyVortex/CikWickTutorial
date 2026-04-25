using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI bilgiMetni;
    public int toplananCezaNesnesi;

    void Start()
    {
        // 1. ADIM: Oyun açıldığında hafızaya bak. "CezaNesnesi" diye bir kayıt var mı? 
        // Varsa onu getir, yoksa 0'dan başla.
        toplananCezaNesnesi = PlayerPrefs.GetInt("CezaNesnesi", 0);
        
        if (bilgiMetni != null)
        {
            bilgiMetni.text = "";
            bilgiMetni.gameObject.SetActive(false);
        }
    }

    public void ObjectCollected()
    {
        // 2. ADIM: Nesne toplandığında sayıyı artır.
        toplananCezaNesnesi++;

        // 3. ADIM: Yeni sayıyı hemen hafızaya (PlayerPrefs) "CezaNesnesi" etiketiyle yaz.
        PlayerPrefs.SetInt("CezaNesnesi", toplananCezaNesnesi);
        
        StopAllCoroutines();
        StartCoroutine(ShowBriefMessage(toplananCezaNesnesi + " / 3 nesne toplandı!"));
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
}