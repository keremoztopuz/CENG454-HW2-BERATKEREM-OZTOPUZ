using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private FlightExamController examManager;

    public float speed;
    public float maxSpeed = 500f;
    public float minSpeed = 0f;
    public float rotspeed1 = 25f;
    public float rotspeed2 = 25f;

    private bool hasTakenOff = false;

    private Rigidbody rb;

    void Start()
    {
        
    }

    void Update() 
    {
        transform.position += -transform.forward * Time.deltaTime * speed;

        if(Input.GetKey(KeyCode.Space)){
            if(speed < maxSpeed){
                speed += 50f * Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            if(speed > minSpeed){
                speed -= 50f * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(Vector3.back * rotspeed1 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(Vector3.forward * rotspeed1 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(Vector3.right * rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(Vector3.left * rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up * rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.down * rotspeed2 * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.M)){
            examManager.OnMissileHit();
            examManager.ResetMission();
            speed = 0;
            rotspeed1 = 0;
            rotspeed2 = 0;
        }

        if(!hasTakenOff && transform.position.y >= 20) {
            examManager.OnTakeoff();
            hasTakenOff = true;
        }

    }
}