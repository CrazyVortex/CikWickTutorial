using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera fpsCam;           // Karakterin kamerası
    public Transform firePoint;     // Oluşturduğun FirePoint
    public float range = 100f;      // Menzil
    public AudioSource shotSound;   // Ateş sesi

    void Update()
    {
        // Sol tık basıldığında
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Sesi çal
        if(shotSound != null) shotSound.Play();

        // Raycast (Işın) fırlat
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " objesini vurdun!");
            
            // İLERİDE: Buraya vurduğun şeyin canını azaltma kodu gelecek.
        }
    }
}