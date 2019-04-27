using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Transform Blaster;
    public GameObject bulletPrefab;
    public float bulletForce = 30;
    public float fireRate = 0.5f;
    private float fireTimer = 0;
    public Text Ammo;
    public float maxAmmo;
    public float currentAmmo;
    public bool IsAI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAI)
        {
            if (Input.GetMouseButton(0))
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0;


                    //fires the guns
                    GameObject bullet = Instantiate(bulletPrefab, Blaster.transform.position, Blaster.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bulletForce);
                }
            }
        }
        else
        {

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (IsAI)
        {
            if (other.gameObject.GetComponent<Playerhealth>())
            {
                Debug.Log("Fucking shoot me in the face bitch.");

                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0;


                    //fires the guns
                    GameObject bullet = Instantiate(bulletPrefab, Blaster.transform.position, Blaster.transform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bulletForce);
                }
            }
        }
    }
}