using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player plr;
    GameObject trail;
    Material mat01;
    Material mat02;
    Material mat03;
    Material mat04;
    Material mat05;
    
   

    // Start is called before the first frame update
    void Start()
    {
        plr = GameObject.FindObjectOfType<Player>();
        trail = GameObject.FindGameObjectWithTag("Trail");
        mat01 = Resources.Load("mat01") as Material;
        mat02 = Resources.Load("mat02") as Material;
        mat03 = Resources.Load("mat03") as Material;
        mat04 = Resources.Load("mat04") as Material;
        mat05 = Resources.Load("mat05") as Material;

        Material[] obstacleMaterials = new Material[5]{mat01, mat02, mat03, mat04, mat05};

        int randomIndex = Random.Range(0, 5);
        gameObject.GetComponent<Renderer>().material = obstacleMaterials[randomIndex];
        
          
    }

    void OnCollisionEnter(Collision collision)
    {
        //Kill the player
        if (collision.gameObject.name == "Player")
        {
            plr.Die();
            trail.GetComponent<TrailRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
