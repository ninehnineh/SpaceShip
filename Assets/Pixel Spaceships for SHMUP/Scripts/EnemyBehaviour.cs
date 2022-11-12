using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float hp;

    public float bulletPerSec = 1;

    private float perSecShot;

    public GameObject bullet;

    private float counter = 0f;
    AudioSource audioSource;

    public float coolEngineTime = 0;
    public float fireTime = 0;

    public BloodbarBehaviour HpBar;

    void Start()
    {
        GetComponent<Animator>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.enabled = false;
        }
        this.HpBar.capacity = this.hp;
    }

    private float sleepCounter = 0;

    private float fireCounter = 0;

    private bool shoot = true;

    void Update()
    {
        perSecShot = 1f / bulletPerSec;
        counter += Time.deltaTime;
        if (counter >= perSecShot && shoot)
        {
            Shot();
            counter = 0;
        }

        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            shoot = false;
            sleepCounter -= Time.deltaTime;
            if (sleepCounter <= 0)
            {
                shoot = true;
                fireCounter = fireTime;
                sleepCounter = coolEngineTime;
            }
        }
    }

    private void Shot()
    {
        GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public async void Explodes(float damage)
    {
        hp -= damage;
        if (HpBar != null)
        {
            HpBar.DamagedBy(damage);
        }
        if (hp <= 0)
        {
            GetComponent<Animator>().enabled = true;
            await System.Threading.Tasks.Task.Delay(700);
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.enabled = true;
            audioSource.PlayOneShot(clip);
        }
    }

    // public void OnCollisionEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         Debug.Log("cham");
    //     }
    // }
}
