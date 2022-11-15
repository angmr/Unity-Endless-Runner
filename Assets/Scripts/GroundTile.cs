using UnityEngine;

public class GroundTile : MonoBehaviour
{   
    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

        for (int i=0; i<4; i++)
        {
             SpawnObstacle();
        }
       
    }

    void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        //Destroys the game object 5 sec after the player leaves the trigger
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2,11);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //Spawn obstacle at that position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
