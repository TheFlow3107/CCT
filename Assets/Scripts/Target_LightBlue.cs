using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_LightBlue : MonoBehaviour
{
    public ParticleSystem hittParticles;
    public AudioSource TargetSound;
    public bool isDestroyed;

    float xStart;
    float xChange;
    float yStart;
    float yChange;

    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        TargetSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        xStart = transform.position.x;
        xChange = Random.Range(1f, 2f) * Time.deltaTime;
        yStart = transform.position.y;
        yChange = Random.Range(1f, 2f) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        TargetRotation();

        MoveDiagonal();

        if (isDestroyed == true)
        {
            Instantiate(hittParticles, transform.position, Quaternion.identity);
            Debug.Log("Light-Blue was Destroyed.");
            ScoreManager.instance.AddPoints("Light-Blue");
            RandomTargetSpawner.instance.TargetDestroyed("Light-Blue");
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

    void MoveDiagonal()
    {
        float yNew = transform.position.y + yChange;
        float xNew = transform.position.x + xChange;

        transform.position = new Vector3(xNew, yNew, transform.position.z);

        if (((xNew > xStart + 3) || (xNew < xStart - 2)) && ((yNew > yStart + 3) || (yNew < yStart - 2)))
        {
            yChange = -1 * yChange;
            xChange = -1 * xChange;
        }
    }
}
