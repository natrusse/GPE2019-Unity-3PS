using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    public Transform selfTransform;
    public EnemyHealth enemyHealth;
    public NavMeshAgent nav;
    public Animator anim;

    Vector3 input;
    public SpawnScript spawner;

    // Use this for initialization

    private void Awake()
    {
        selfTransform = GetComponent<Transform>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    private void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (target && nav)
        {
            nav.destination = target.position;
            input = Vector3.MoveTowards(input, nav.desiredVelocity, nav.acceleration * Time.deltaTime);
            input = selfTransform.InverseTransformDirection(input);
            anim.SetFloat("Horizontal", input.x);
            anim.SetFloat("Vertical", input.z);

        }
        else
        {
            Debug.Log("Either there is no target, or there is no navmeshagent on this object");
        }



    }

    private void OnDestroy()
    {
        if (spawner)
        {
            spawner.totalEnemies--;
            spawner.spawnLimit++;
            spawner.killStreak++;
            if (spawner.spawnLimit == 75)
            {
                spawner.spawnLimit = -50;
            }
        }
        else
        {
            Debug.LogError("Why?");
        }
    }
}
