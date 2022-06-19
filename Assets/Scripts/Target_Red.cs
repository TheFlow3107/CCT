using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Red : MonoBehaviour
{
    public ParticleSystem hittParticles;
    public AudioSource TargetSound;
    public bool isDestroyed;
    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation();

        if (isDestroyed == true)
        {
            Instantiate(hittParticles, transform.position, Quaternion.identity);
            Debug.Log("Red was Destroyed.");
            ScoreManager.instance.AddPoints("Red");
            RandomTargetSpawner.instance.TargetDestroyed("Red");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Balls")
        {
            TargetSound.Play();
            isDestroyed = true;
        }
    }

    void TargetRotation()
    {
        Vector3 lookVector = playerPosition - transform.position;

        transform.rotation = Quaternion.LookRotation(lookVector);
    }
}
