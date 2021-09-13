using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    Rigidbody rb;
    Transform target;

    [Header("추격속도")]
    [SerializeField] [Range(30f, 50f)] float MoveSpeed = 40f;
    [SerializeField] GameObject obj;
    [Header("근접거리")]
    [SerializeField] [Range(0f, 20f)] float contactDist = 10f;

    Vector3 init;
    bool follow = false;
    void Start()
    {
        follow = false;
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        init = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, target.transform.position) <= 200)
        {
            obj.SetActive(true);
            FollowTarget();

        }
        else
            obj.SetActive(false);
            
    }

    void FollowTarget()
    {

        if (Vector3.Distance(transform.position, target.transform.position) >=0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);
        }
        else
            rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player") {
            this.transform.position = init;
            GameObject.Find("Player").transform.position = new Vector3(-533.3f,117.8f,-3153.5f);
        }
    }

}
