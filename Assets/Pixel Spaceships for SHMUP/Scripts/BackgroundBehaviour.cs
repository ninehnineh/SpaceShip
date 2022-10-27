using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float velocity;

    private bool isTopMost = false;

    private float topMostY = 0f;
    private float bottomMostY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        topMostY = GameObject.Find("BackgroundTopMost").transform.position.y;
        bottomMostY = GameObject.Find("BackgroundBottomMost").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * velocity * Time.deltaTime;

        if (transform.position.y <= bottomMostY)
        {
            transform.position = new Vector3(transform.position.x, topMostY, 0);
        }
    }
}
