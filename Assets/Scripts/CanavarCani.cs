using UnityEngine;

public class CanavarCani : MonoBehaviour
{
    public int can = 3;
    public void HasarAl(int miktar)
    {
        can -= miktar;
        Debug.Log("Canavar hasar aldı. Kalan can: " + can);
        if (can <= 0)
        {
            Oldur();
        }
    }
    void Oldur()
    {
        Debug.Log("Canavar öldü!");
        Destroy(gameObject); // Canavarı sahneden siler
    }
}
