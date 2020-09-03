using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    private float _speed;

    public float minSpeed = 1f;
    public float maxSpeed = 2f;

    public float minX = -8.15f;
    public float maxX = 8.15f;
    
    public float minY = -4.15f;
    public float maxY = 4.15f;

    public float secondsToMaxDifficulty = 50f;

    Vector2 targetPosition;

    void Start()
    {
        Time.timeScale = 1;
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        if((Vector2)transform.position != targetPosition)
        {
            _speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition(); 
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
