using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject[] planets;
    public float speed;
    private Vector2 target;
    public float lifeTime;
    private GameMaster gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        planets = GameObject.FindGameObjectsWithTag("Planet");

        int rand = Random.Range(0, planets.Length);
        target = planets[rand].transform.position;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,target) < lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
        {
            gm.GameOver();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
