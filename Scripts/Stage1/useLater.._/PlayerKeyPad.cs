using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyPad : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed = 5f;
    float dirX;

    [SerializeField]
    GameObject codePanel, closedSafe, openSafe;

    public static bool isSafeOpened = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openSafe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openSafe.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, 1);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name.Equals("Safe") && !isSafeOpened)
        {
            codePanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Equals("Safe"))
        {
            codePanel.SetActive(false);
        }
    }
}
