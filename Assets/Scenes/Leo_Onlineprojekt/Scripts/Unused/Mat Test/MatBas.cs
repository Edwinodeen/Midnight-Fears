using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatBas : MonoBehaviour
{

    protected string mat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Eat();
        }

    }
    public virtual void Eat()
    {
        print("You ate " + gameObject.name);
    }
}
