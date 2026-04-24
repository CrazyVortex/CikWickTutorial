using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //yazı için
using System.Collections; //zamanlama için

public class GameManager : MonoBehaviour
{
    private int toplamObje = 3;
    private int toplananObje;
    public TextMeshProUGUI bilgiMetni;
    public string koyYeri = "KoySahnesi";
    public float yaziBeklemeZamani = 5.0f;

    public void ObjectCollected()
    {
        toplananObje++;
        if (toplananObje < toplamObje)
        {
            StopAllCoroutines(); // eski yazıyı durdurur
            StartCoroutine(ShowBriefMessage(toplananObje + " / " + toplamObje + " bulundu"));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FinishLevel());
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bilgiMetni != null)
        {
            bilgiMetni.text = ""; //yazıyı temizle
            bilgiMetni.gameObject.SetActive(false); //yazıyı gizle
        }
    }

    IEnumerator ShowBriefMessage(string message) //kısa mesaj
    {
        bilgiMetni.text = message; //mesajı yaz
        bilgiMetni.gameObject.SetActive(true); //görünür olsun

        yield return new WaitForSeconds(yaziBeklemeZamani); //belirlenen saniye kadar yazı görünür

        bilgiMetni.gameObject.SetActive(false);
    }
    IEnumerator FinishLevel()
    {
        bilgiMetni.text = "Zindandan Çıktın!";
        bilgiMetni.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(koyYeri); //ışınlama bitiş
    }
}