using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioSource ses;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
    void Collect()
    {
        if(ses != null)
        {
            AudioSource.PlayClipAtPoint(ses.clip, transform.position);
        }
        Object.FindAnyObjectByType<GameManager>().ObjectCollected();
        Destroy(gameObject);
    }
}