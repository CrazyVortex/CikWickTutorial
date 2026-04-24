using UnityEngine;

public class OyuncuSaldiri : MonoBehaviour
{
    public float saldiriMesafesi = 3f;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //fare sol tıklanınca saldırır
        {
            Vur();
        }
    }
    void Vur()
    {
        RaycastHit hit;  // ışın fırlatma raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit, saldiriMesafesi))
        {
            CanavarCani canavar = hit.transform.GetComponent<CanavarCani>(); //vurduğumuz kişide canavarcanı kodu varsa

            if (canavar != null)
            {
                canavar.HasarAl(1); // 1 hasar veriri
            }
        }
    }
}
