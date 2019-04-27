using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour {

    public Transform selfTransform;
    public float shelfLife;
    public bool despawnItem;

    private void Awake()
    {
        selfTransform = GetComponent<Transform>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 50, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Playerhealth>())
        {
            other.gameObject.GetComponent<Playerhealth>().TakeDamage(-20);
            Destroy(gameObject);
        }

        if (despawnItem)
        {
            Destroy(gameObject, shelfLife);
        }
    }
}
