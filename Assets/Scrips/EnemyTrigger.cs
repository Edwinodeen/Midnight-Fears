using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour ///Leos kod
{
    public GameObject TriggerEnemy;
    public GameObject spawnPosition;

    public float lowerBound;
    public float higherBound;

    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.triggerColided)
        {
            playerMovement.triggerColided = false;

            float random = Random.value;
            if (random >= lowerBound && random <= higherBound)
            {
                Instantiate(TriggerEnemy, spawnPosition.transform.position, Quaternion.Euler(0, 0, 0));
                print("SCAAAASRYYY!!! :0");
            }
        }
    }

           
}
