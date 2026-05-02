using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string hedefSahne;
    void OnTriggerEnter(Collider other) //Temas Kontrolu
    {
        if(other.CompareTag("Player")) //Karakter ise
        {
            SceneManager.LoadScene(hedefSahne); //sahneye ışınlan
        }
    }
}
