using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCode : MonoBehaviour ///Leos kod
{
    float timer;
    bool startTimer;
    public float aliveTime;

    public GameObject target;  
    public float speed = 5f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target.transform);

        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if(timer > aliveTime)
        {
            Destroy(this.gameObject);
        }
    }
}
