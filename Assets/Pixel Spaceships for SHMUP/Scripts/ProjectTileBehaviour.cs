using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileBehaviour : MonoBehaviour
{

    public float Speed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;

        if (transform.position.magnitude > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyBehaviour e = other.collider.GetComponent<EnemyBehaviour>();

        if (e != null)
        {   
            Destroy(gameObject);
            e.DestroyEnemyShip();
            e.animatora();
        }

    }
}
