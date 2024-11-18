using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class EnemyBehavior : MonoBehaviour

//https://www.youtube.com/watch?v=UjkSFoLxesw&t=278s
{
    [Header("Enemy AI")]

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, whatisPlayer;
    public Vector3 walkPt;
    bool walkPtSet;
    public float walkPtRange;
    public float timeBtxAttack;
    bool Attacked;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    //public TargetRange tr;

    public GameObject Bullet;

    [Header("Enemy Stats")]
    public int enemyHealth;
    public GameManager gm;

    private IObjectPool<EnemyBehavior> enemyPool;

    public void SetPool(IObjectPool<EnemyBehavior> pool)
    {
        enemyPool = pool;
    }


    public void Awake()
    {
        //player = tr.target;
        //player = tr.p.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        //change to colliders
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);
        //player = tr.target;
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange)  Chasing();
        if (playerInSightRange && playerInAttackRange) Attacking();
    }

    private void Patroling()
    {
        Debug.Log("Patroling");
        if (!walkPtSet) SearchWalkPt();
        if (walkPtSet)
        {
            agent.SetDestination(walkPt);
        }
        Vector3 distanceToWalk = transform.position - walkPt;

        if(distanceToWalk.magnitude < 1f)
        {
            walkPtSet = false;
        }
    }
    private void SearchWalkPt()
    {
        float randZ = Random.Range(-walkPtRange, walkPtRange);
        float randX = Random.Range(-walkPtRange, walkPtRange);

        walkPt = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);
        if(Physics.Raycast(walkPt, -transform.up, 2f, Ground))
        {
            walkPtSet = true;
        }
    }

    private void Attacking()
    {
        Debug.Log("Attack!");
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!Attacked)
        {
            Rigidbody rb = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

            Attacked = true;
            Invoke(nameof(ResetAttack), timeBtxAttack);
        }
    }
    private void Chasing()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }

    private void ResetAttack()
    {
        Attacked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakingDamage();
        }
    }


    public void TakingDamage()  
    {
        if(enemyHealth <= 0)
        {
            gm.TotalAddGold(5);
            gameObject.SetActive(false);
            enemyPool.Release(this);
        }
        else
        {
            enemyHealth -= 10;
        }

    }
}

