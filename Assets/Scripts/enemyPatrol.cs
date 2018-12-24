using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour {

    //[SerializeField]
    //private Transform[] navPoints;
    //[SerializeField]
    //private Transform player;
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;

    public Transform[] waypoints;
    public int currentLocation = 0;
    public int speed = 3;
    public Transform target;
    public float maxHealth = 15;
    public GameObject healthBar;
    private float currentHealth;
     
    private void Start()
    {
        currentHealth = maxHealth;
        if (agent == null)
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, .3f, .1f);
        Transform PTrans = waypoints[currentLocation].transform;
        this.gameObject.transform.LookAt(PTrans);
    }
    public void damageEnemy(Vector3 damage)
    {
        currentHealth -= damage.magnitude;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    //void RunAwayFromPlayer()
    //{
    //    if (currentHealth <= 5)
    //    {
    //        float furthestDistanceSoFar = 0;
    //        Vector3 runPosition = Vector3.zero;

    //        foreach (Transform point in navPoints)
    //        {
    //            print(Vector3.Distance(player.position, point.position));
    //            float currentCheckDistance = Vector3.Distance(player.position, point.position);
    //            if (currentCheckDistance > furthestDistanceSoFar)
    //            {
    //                furthestDistanceSoFar = currentCheckDistance;
    //                runPosition = point.position;
    //            }
    //        }

    //        agent.SetDestination(runPosition);
    //    }
    //}
           

    public void patrol(){//GetComponent<NavMeshAgent>().SetDestination(target.position);
        if (transform.position.y != waypoints[currentLocation].transform.position.y)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentLocation].transform.position, speed * Time.deltaTime);
        }
        if (transform.position.y == waypoints[currentLocation].transform.position.y)
        {
            currentLocation += 1;
        }
        if (currentLocation >= waypoints.Length)
        {
            currentLocation = 0;
        }
    }

   
}