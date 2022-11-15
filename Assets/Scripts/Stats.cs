using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject player;
    Player plrScript;
    Rigidbody plrRigidBody;
    Text distanceText;
    Text speedText;
    Text timeAliveText;
    string displayedDistance;
    float plrDistance;
    string displayedSpeed;
    float plrSpeed;
    string displayedTimeAlive;
    float plrTimeAlive;

    // Start is called before the first frame update
    void Start()
    {
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        speedText = GameObject.Find("SpeedText").GetComponent<Text>();
        timeAliveText = GameObject.Find("TimeAliveText").GetComponent<Text>();
        plrScript = player.GetComponent<Player>();
        plrRigidBody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        plrDistance = (player.transform.position.z) - 10f;
        plrSpeed = plrRigidBody.velocity.magnitude;
        plrTimeAlive = Time.timeSinceLevelLoad;

        if (plrScript.plrOnGround == true){
            //plrDistance = Mathf.RoundToInt(plrDistance);
            displayedDistance = "Distance Traveled: " + plrDistance.ToString("0") + " m";
            distanceText.text = displayedDistance;
            //plrSpeed = Mathf.RoundToInt(plrSpeed);
            displayedSpeed = "Current Speed: " + plrSpeed.ToString("0") + " m/s";
        }else{
            displayedSpeed = "Current Speed: - ";
            }
        
    
        if (plrScript.alive == true){
            displayedTimeAlive = "Time Alive: " + plrTimeAlive.ToString("0") + " s";
        }

        speedText.text = displayedSpeed;
        timeAliveText.text = displayedTimeAlive;
    }
}
