using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;

    private GameMaster gm;

    private AudioSource audioSource;

    public GameObject selectEffect;
    public GameObject deathEffect;
    public GameObject electricDeath;
    public GameObject poisonDeath;
    public GameObject fireDeath;
    public GameObject frostDeath;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(Input.touchCount > 0 && !IsPointerOverUIObject())
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    
                    if (col == touchedCollider)
                    {
                        Instantiate(selectEffect, transform.position, Quaternion.identity);
                        audioSource.Play();
                        moveAllowed = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (moveAllowed && col == touchedCollider)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                    break;

                case TouchPhase.Ended:
                    moveAllowed = false;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet" || collision.tag == "Projectile")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gm.GameOver();
        }
        if (collision.tag == "ElectricOrb")
        {
            Instantiate(electricDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gm.GameOver();
        }
        if (collision.tag == "Spiky")
        {
            Instantiate(poisonDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gm.GameOver();
        }
        if (collision.tag == "FireOrb")
        {
            Instantiate(fireDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gm.GameOver();
        }
        if (collision.tag == "FreezeOrb")
        {
            Instantiate(frostDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gm.GameOver();
        }
    }

    // to avoid clicks on Game screen while UI is active

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}


/*




 if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                { 
                    Instantiate(selectEffect, transform.position, Quaternion.identity);
audioSource.Play();
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }

*/