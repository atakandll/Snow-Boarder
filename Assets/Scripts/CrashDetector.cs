using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 0.1f;
    CircleCollider2D playerHead;
    bool hasCrashed = false;

    private void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && !hasCrashed)
        {

            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("RealoadScene", loadDelay);

        }
    }

    void RealoadScene()
    {
        SceneManager.LoadScene(0);

    }























}
    
