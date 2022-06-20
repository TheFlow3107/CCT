using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Yellow : MonoBehaviour
{
    public ParticleSystem hittParticles;
    public AudioSource TargetSound;
    public bool isDestroyed;
    float yStart;
    float yChange;

    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        yStart = transform.position.y;
        yChange = Random.Range(-1f, 1f) * Time.deltaTime;
        TargetSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation();

        MoveUpDown();

        if (isDestroyed == true)
        {
            Instantiate(hittParticles, transform.position, Quaternion.identity);
            Debug.Log("Yellow was Destroyed.");
            ScoreManager.instance.AddPoints("Yellow");
            RandomTargetSpawner.instance.TargetDestroyed("Yellow");
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

    void MoveUpDown()
    {
        float yNew = transform.position.y + yChange;

        transform.position = new Vector3(transform.position.x, yNew, transform.position.z);

        if ((yNew > yStart + 3) || (yNew < yStart - 2))
        {
            yChange = -1 * yChange;
        }
    }

    void TargetRotation()
    {
        Vector3 lookVector = playerPosition - transform.position;

        transform.rotation = Quaternion.LookRotation(lookVector);
    }
}
