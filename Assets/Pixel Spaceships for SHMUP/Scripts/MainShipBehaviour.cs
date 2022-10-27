using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShipBehaviour : MonoBehaviour
{

    private Camera mainCamera;

    public ProjectTileBehaviour ProjectTilePrefab;
    public Transform LaunchOffset;

    float fireSpeed = 0.5f;

    bool isShooting = true;

    float timer;
    public float waitingTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosition();

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer > waitingTime)
        {
            Instantiate(ProjectTilePrefab, LaunchOffset.position, transform.rotation);
            timer = 0;
        }
    }

    private void FixedUpdate()
    {

    }
    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
