using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] ParticleSystem explosionParticle;
    void FixedUpdate()
    {
        transform.Translate(Vector3.back * Time.deltaTime * force, Space.World);
        if (transform.position.magnitude > 200)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            explosionParticle.transform.position = collision.contacts[0].point;
            Instantiate(explosionParticle);

            collision.collider.gameObject.GetComponent<Spaceship>().GameOver();
        }
    }
}
