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

    AudioSource audioSource;

    public AudioClip shootSound;
    public AudioClip deadSound;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        GetComponent<Animator>().enabled = false;

        audioSource = GetComponent<AudioSource>();

        audioSource.enabled = false;

        hpBar.GetComponent<BloodbarBehaviour>().capacity = this.hp;

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
            PlaySound(shootSound);

        }

        if (!isAlive)
        {
            gameOverSreen.Setup(0);
        }

    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public float hp;
    public GameObject hpBar;
    public async void Explodes(float damage)
    {
        hp -= damage;
        hpBar.GetComponent<BloodbarBehaviour>().DamagedBy(damage);
        if (hp <= 0)
        {
            GetComponent<Animator>().enabled = true;
            await System.Threading.Tasks.Task.Delay(700);
            Destroy(gameObject);
            isAlive = false;
            Debug.Log("Over " + hp);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(clip);
    }

}
