using UnityEngine;
using UnityEngine.AI; // NavMesh için şart

public class CanavarAI : MonoBehaviour
{
    public Transform hedef; // Player buraya sürüklenecek
    public float takipMesafesi = 15f; // Seni ne kadar uzaktan fark etsin?
    public float saldiriMesafesi = 2f; // Ne kadar yaklaşınca dursun/vursun?
    
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (hedef == null) 
            hedef = GameObject.FindWithTag("Player").transform; // Otomatik bulur
    }

    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, hedef.position);

        if (mesafe < takipMesafesi)
        {
            // Oyuncuya doğru yürü
            agent.SetDestination(hedef.position);
            
            // Eğer çok yaklaştıysa dur (üzerine çıkmasın)
            if (mesafe <= saldiriMesafesi)
            {
                agent.isStopped = true;
                // Burada animasyon tetiklenebilir (Saldırı animasyonu)
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }
}
