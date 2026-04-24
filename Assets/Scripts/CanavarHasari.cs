using UnityEngine;

public class CanavarHasari : MonoBehaviour
{
    public float hasarMiktari = 10f; //canavarın ne kadar hasar verceği
    public float saldiriAraliği = 1.5f;
    private float sonrakiSaldiriSuresi;

    private void OnTriggerEnter(Collider other) //objeye temas edince çalışır
    {
        if (other.CompareTag("Player")) //playera temas ediyorsa
        {
            if (Time.time >= sonrakiSaldiriSuresi) 
            {
                CanBari oyuncuCani = other.GetComponent<CanBari>(); //canbarı scriptine ulaşmak için
                if (oyuncuCani != null)
                {
                    oyuncuCani.HasarAlma(hasarMiktari);
                    Debug.Log("Canavar oyuncuya vurdu.");
                    sonrakiSaldiriSuresi = Time.time + saldiriAraliği; //bir sonraki saldırı için bekleme süresini ayarlama
                }
            }
        }   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
