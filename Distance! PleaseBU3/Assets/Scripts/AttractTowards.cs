using UnityEngine;

public class AttractTowards : MonoBehaviour
{

    public GameObject Planet;
    public float speed = 1f;

    public Vector2 target;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Planet != null)
        {
            target = Planet.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
