using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI bilgiMetni;
    public int toplananCezaNesnesi;

    // Listenin adı Item koduyla aynı: toplananIDler
    public static List<string> toplananIDler = new List<string>();

    void Start()
    {
        toplananCezaNesnesi = PlayerPrefs.GetInt("CezaNesnesi", 0);
        
        if (bilgiMetni != null)
        {
            bilgiMetni.text = "";
            bilgiMetni.gameObject.SetActive(false);
        }
    }

    public void ObjectCollected(string id)
    {
        if (!toplananIDler.Contains(id))
        {
            toplananIDler.Add(id);
            toplananCezaNesnesi++;
            PlayerPrefs.SetInt("CezaNesnesi", toplananCezaNesnesi);
            
            StopAllCoroutines();
            StartCoroutine(ShowBriefMessage(toplananCezaNesnesi + " / 3 nesne toplandı!"));
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
}