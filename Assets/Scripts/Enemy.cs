using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public ParticleSystem deathParticle;

    public float rotationSpeed;
    public float distance;
    public Gradient whiteColor;
    public Gradient greyColor;

    public LineRenderer lineOfSight;

    public AudioSource deathSound;




    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        deathSound = GetComponent<AudioSource>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.white);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = whiteColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Instantiate(deathParticle, GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation);
                deathSound.Play();
                Destroy(hitInfo.collider.gameObject);
				Application.LoadLevel(0);

            }

        } else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.grey);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greyColor;
        }

        lineOfSight.SetPosition(0, transform.position);

    }




}
