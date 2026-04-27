using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera fpsCam;           
    public Transform firePoint;     
    public float range = 100f;      
    public AudioSource shotSound;   
    public int hasarGucu = 1; // Her atışta kaç can gitsin?

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(shotSound != null) shotSound.Play();

        RaycastHit hit;
        // Işını kameranın biraz önünden başlatıyoruz (Dibine girenleri vurabilmek için)
        Vector3 rayOrigin = fpsCam.transform.position + fpsCam.transform.forward * 0.2f;

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " objesini vurdun!");
            
            // --- CANAVARA HASAR VERME KISMI BURASI ---
            CanavarCani canavar = hit.transform.GetComponent<CanavarCani>();
            
            if (canavar != null)
            {
                canavar.HasarAl(hasarGucu);
            }
            // -----------------------------------------
        }
    }
}