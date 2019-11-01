using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Want to transfer information of target to bullet

    private Transform target;

    public float speed = 70f;
    public int damage = 50;

    public float explosionRadius = 0f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }   

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed*Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //dir.magnitude is distance to target, if this is less than this then we have already hit the target we dont want to overshoot, want to hit before we move past the target
        {
            HitTarget();
            return;
        }
        //if we have not hit the object yet then we move
        transform.Translate(dir.normalized*distanceThisFrame, Space.World);
        transform.LookAt(target);


    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }

        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        } 
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
