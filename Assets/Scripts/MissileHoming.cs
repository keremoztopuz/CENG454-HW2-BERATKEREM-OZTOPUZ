using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 50f;
    private Transform target;
    
    [SerializeField] private FlightExamController examManager;

    public void SetTarget(Transform newTarget) {
        target = newTarget;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null) return;
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        examManager.OnMissileHit();
        Destroy(gameObject);
    }
}
