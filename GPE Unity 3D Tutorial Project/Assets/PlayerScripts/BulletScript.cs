using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float despawnTime = 5;
    private float timer = 0;
    public float speed = 5f;

    Transform tf;
    Rigidbody rigid;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        rigid.AddForce(tf.forward * speed * Time.deltaTime);

        if (timer >= despawnTime)
        {

            Destroy(gameObject);

        }
    }
}
