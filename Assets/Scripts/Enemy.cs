using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawnPoint;
    public Rigidbody bulletPrefab;
    public float shootSpeed = 10;

    private float lastAttackTime = 0f;
    private float fireRate = 0.5f;
    public float playerDistance;
    public float awareAI = 10f;
    public float AIMoveSpeed;
    public float damping = 6.0f;

    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int destPoint = 0;
    public Transform goal;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;

        agent.autoBraking = false;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < awareAI)
        {
            //LookAtPlayer();
            if(playerDistance < 2f & Time.time - lastAttackTime >= 1f / fireRate)
            {
                shootBullet();
                lastAttackTime = Time.time;
            }
            else
            {
                GotoNextPoint();
            }
        }
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

/*    void LookAtPlayer()
    {
        transform.LookAt(player);
    }
*/

    void GotoNextPoint()
    {
        if (navPoint.Length == 0)
        {
            return;
        }
        agent.destination = navPoint[destPoint].position;
        destPoint = (destPoint + 1) % navPoint.Length;
    }

    void shootBullet()
    {
        var projectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //Shoot the Bullet in the forward direction of the player
        projectile.velocity = bulletSpawnPoint.forward * shootSpeed;
    }

    void FixedUpdate()
    {
        
    }
}
