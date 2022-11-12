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

    public BloodbarBehaviour HpBar;

    void Start()
    {
        GetComponent<Animator>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
    }

    void Update()
    {
        perSecShot = 1f / bulletPerSec;
        counter += Time.deltaTime;
        if (counter >= perSecShot)
        {
            Shot();
            counter = 0;
        }
    }

    private void Shot()
    {
        GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public async void Explodes(float damage)
    {
        hp -= damage;
        HpBar.DamagedBy(damage);
        if (hp <= 0)
        {
            GetComponent<Animator>().enabled = true;
            await System.Threading.Tasks.Task.Delay(700);
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(clip);
    }

    // public void OnCollisionEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         Debug.Log("cham");
    //     }
    // }
}
