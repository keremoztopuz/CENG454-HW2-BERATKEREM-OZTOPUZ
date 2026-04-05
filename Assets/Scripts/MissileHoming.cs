using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 50f;
    private Transform target;
    
    [SerializeField] private FlightExamController examManager;

    public void SetTarget(Transform newTarget) {
        Debug.Log("Target set: " + newTarget.name);
        target = newTarget;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null) return;
        transform.LookAt(target);
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        examManager.OnMissileHit();
        Destroy(gameObject);
    }
}
