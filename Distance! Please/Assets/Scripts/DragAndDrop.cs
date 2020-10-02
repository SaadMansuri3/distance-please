using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col = null;
    int flag = 0;
    private int fingerId = -1;
    private GameMaster gm = null;

    private AudioSource audioSource;

    public GameObject selectEffect;
    public GameObject deathEffect;
    public GameObject electricDeath;
    public GameObject poisonDeath;
    public GameObject fireDeath;
    public GameObject frostDeath;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !IsPointerOverUIObject())
        {
            for (int i = 0; i < 1 ; i++) //Input.touchCount
            {
                Touch touch = Input.GetTouch(i);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    if (fingerId >= 0)
                    {
                        if (fingerId == touch.fingerId)
                        {
                            if (touch.phase == TouchPhase.Moved && flag == 1)
                            {
                                transform.position = new Vector2(touchPosition.x, touchPosition.y);
                            }
                            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                            {
                                flag = 0;
                                fingerId = -1;
                            }
                        }
                    }
                    else
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            Instantiate(selectEffect, transform.position, Quaternion.identity);
                            audioSource.Play();
                            fingerId = touch.fingerId;
                            flag = 1;
                        }
                    }
                }
            }
        }
        else
        {
            fingerId = -1;
            flag = 0;
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
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}