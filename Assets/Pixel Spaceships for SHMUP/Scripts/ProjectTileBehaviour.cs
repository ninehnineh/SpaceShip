using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class ProjectTileBehaviour : MonoBehaviour
{

    public float Speed = 4.5f;

    public bool isEnemyBullet;

    private Rigidbody2D rigidbody2D;

    private bool explode;

    private Vector3 moveDirect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator.enabled = false;
        moveDirect = isEnemyBullet ? Vector3.down : Vector3.up;
    }

    private float liveTime;

    // Update is called once per frame
    void Update()
    {
        liveTime += Time.deltaTime;

        if (explode)
        {
            return;
        }

        transform.position += new Vector3(0, Time.deltaTime * Speed * (isEnemyBullet ? -1 : 1), 0);

        if (liveTime > 3)
        {
            exploded();
        }
    }

    private async void exploded()
    {
        explode = true;
        animator.enabled = true;
        transform.localScale = Vector3.one * 0.3f;
        await Task.Delay(700);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (isEnemyBullet)
        {
            MainShipBehaviour mainShip = other.collider.GetComponent<MainShipBehaviour>();
            if (mainShip != null)
            {
                mainShip.Explodes();
                exploded();
            }
        }
        else
        {
            EnemyBehaviour enemy = other.collider.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.Explodes();
                exploded();
            }
        }

    }

    Animator animator;
}
