using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GirisKapisi : MonoBehaviour
{
    public TextMeshProUGUI ElenorText;
    public GameObject secimPaneli;
    public Button evetButonu;
    public Button hayirButonu;
    public GameObject elenor;
    public Transform elenorSpawn;
    public Transform Player;
    public string CezaBolgesi;

    void Start()
    {
        // Başlangıçta UI ve Elenor kapalı olsun
        ElenorText.text = "";
        secimPaneli.SetActive(false);
        elenor.SetActive(false);

        // Buton dinleyicilerini ata
        evetButonu.onClick.AddListener(OnYesPressed);
        hayirButonu.onClick.AddListener(OnNoPressed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Kapıdan geçince akışı başlat
            GetComponent<Collider>().enabled = false; // Tetikleyiciyi bir kez çalışması için kapat
            StartCoroutine(TownSequence());
        }
    }

    IEnumerator TownSequence()
    {
        // 1. Yazı: Kasabaya yabancı biri girdi
        ElenorText.text = "Kasabaya yabancı birisi girdi!";
        yield return new WaitForSeconds(3f);
        ElenorText.text = "";

        // 2. Elenor Işınlanma ve Konuşma
        elenor.transform.position = elenorSpawn.position;
        elenor.SetActive(true);
        ElenorText.text = "Elenor: Kasabamızda yabancı istemiyoruz. Hemen buradan git!";
        yield return new WaitForSeconds(3f);
        ElenorText.text = "";

        // 3. Soru ve Butonlar
        ElenorText.text = "Kasabadan gitmek ister misin?";
        secimPaneli.SetActive(true);
    }

    public void OnYesPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Kasaba");
    }

    public void OnNoPressed()
    {
        secimPaneli.SetActive(false);
        StartCoroutine(PunishmentSequence());
    }

    IEnumerator PunishmentSequence()
    {
        ElenorText.text = "Elenor: O zaman seçiminin sonucuna katlanıcaksın!";
        yield return new WaitForSeconds(3f);
        ElenorText.text = "";
        SceneManager.LoadScene(CezaBolgesi); //sahneye ışınlan
    }
}