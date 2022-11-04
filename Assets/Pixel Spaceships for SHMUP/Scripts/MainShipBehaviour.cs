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

    private bool isAlive = true;

    GameOverSreen gameOverSreen;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        GetComponent<Animator>().enabled = false;

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

        if (!isAlive)
        {
            gameOverSreen.Setup(0);
        }

    }

    private void isDestroyed()
    {

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

    public async void Explodes()
    {
        GetComponent<Animator>().enabled = true;
        await System.Threading.Tasks.Task.Delay(700);
        Destroy(gameObject);
        isAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectOfType<GameController>().EndGame();
        
    }


}
