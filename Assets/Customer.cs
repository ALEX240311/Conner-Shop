using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject shelfTarget;
    public float speed = 2f;

    private void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (shelfTarget != null)
        {
            Vector3 direction = (shelfTarget.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
