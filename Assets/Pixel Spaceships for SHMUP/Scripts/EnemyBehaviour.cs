using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public ProjectTileBehaviour ProjectTilePrefab;
    public Transform LaunchOffset;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyEnemyShip()
    {
        Destroy(gameObject);
        Debug.Log("pew!");
    }

    public void animatora()
    {
        GetComponent<Animator>().enabled = true;
        Debug.Log("hell yeah!");
    }
}
