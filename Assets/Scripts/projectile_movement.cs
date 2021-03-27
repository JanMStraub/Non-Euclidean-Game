using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_movement : MonoBehaviour
{
    public float projectileSpeed = 1f;
    public float ttl = 5f;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * projectileSpeed );
        transform.localRotation = GroundNormal();
    }

    Quaternion GroundNormal()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity);
        Debug.DrawRay(hit.point, hit.normal * 10, Color.red);

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        return toRotation;
    }


    void Destroyer()
    {
        if (Time.time - startTime < ttl)
        {
            Destroy(gameObject, 5);
        }
    }
}
