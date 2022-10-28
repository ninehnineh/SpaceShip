using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float bulletPerSec = 1;

    private float perSecShot;

    public GameObject bullet;

    private float counter = 0f;

    void Start()
    {
        GetComponent<Animator>().enabled = false;
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

    public async void Explodes()
    {
        GetComponent<Animator>().enabled = true;
        await System.Threading.Tasks.Task.Delay(700);
        Destroy(gameObject);
    }

}
