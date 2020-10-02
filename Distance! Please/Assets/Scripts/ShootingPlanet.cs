using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingPlanet : MonoBehaviour
{
    public Transform shotPos;
    public GameObject projectile;

    private float _timeBtwnShot;
    public float startTimeBtwnShot;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > 1.5f)
        {
            if (_timeBtwnShot <= 0)
            {
                Instantiate(projectile, shotPos.position, Quaternion.identity);
                _timeBtwnShot = startTimeBtwnShot;
            }
            else
            {
                _timeBtwnShot -= Time.deltaTime;
            }
        }
    }
}
