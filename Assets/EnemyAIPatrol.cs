using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAIPatrol : MonoBehaviour
    //Theo
{
    GameObject Player;

    NavMeshAgent agent;

    [SerializeField] LayerMask GroundLayer, PlayerLayer;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackrange;
    bool playerInSight, playerInAttackRange;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.white;

        Gizmos.DrawLine(transform.position, destPoint);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, PlayerLayer);
        playerInSight = Physics.CheckSphere(transform.position, attackrange, PlayerLayer);

        if(!playerInSight && !playerInAttackRange) patrol();
        if(playerInSight && !playerInAttackRange) Chase();
        if(playerInSight && playerInAttackRange) Attack();
    }

    void Attack()
    {
        


    }
     void Chase()
    {
        agent.SetDestination(Player.transform.position);
    }

     void patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;

    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, GroundLayer))
        {
            walkpointSet = true;
        }
    }


}
