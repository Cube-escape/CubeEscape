using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveSlenderAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent slender;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private LayerMask whatIsGround, whatIsPlayer;

    [SerializeField]
    private Vector3 walkPoint;

    [SerializeField]
    private float walkPointRange;

    private bool walkPointSet;

    [SerializeField]
    private float sightRange;

    [SerializeField]
    private bool playerInSightRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        else ChasePlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        else
            slender.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        Debug.Log(walkPoint);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        slender.SetDestination(player.position);
    }

    public void IncreaseSlender()
    {
        GetComponent<NavMeshAgent>().speed += 0.1f;
        float scaleX = gameObject.transform.localScale.x;
        float scaleY = gameObject.transform.localScale.y;
        float scaleZ = gameObject.transform.localScale.z;
        gameObject.transform.localScale = new Vector3(scaleX * 1.1f, scaleY * 1.1f, scaleZ * 1.1f);
    }
}
