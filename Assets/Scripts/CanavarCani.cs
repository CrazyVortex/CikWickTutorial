using UnityEngine;

public class CanavarCani : MonoBehaviour
{
    public int can = 3;

    public void HasarAl(int miktar)
    {
        can -= miktar;
        Debug.Log(gameObject.name + " hasar aldı. Kalan can: " + can);

        if (can <= 0)
        {
            Oldur();
        }
    }

    void Oldur()
    {
        Debug.Log(gameObject.name + " öldü!");
        Destroy(gameObject); 
    }
}