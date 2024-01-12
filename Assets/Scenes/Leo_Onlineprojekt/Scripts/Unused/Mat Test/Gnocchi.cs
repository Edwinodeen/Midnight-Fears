using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnocchi : MatBas
{
    // Start is called before the first frame update
    void Start()
    {
        mat = "Gnocchi";
    }


    public override void Eat()
    {
        gameObject.name = "Gnocchi";
    }
}
