using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public bool isActive=false;
    Rigidbody2D rb;
    Camera cam;
    public GameObject trailPrefabs;
    GameObject currentTrail;
    CircleCollider2D circleColl;

    public float minDistane;
    Vector2 previousPos;
    Vector2 mousePos;
    private void Start()
    {
        circleColl = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }

        if(isActive)
        {
            UpdateCutOb();
        }

    }

    void UpdateCutOb()
    {
         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         rb.position = mousePos;

        float velocity = (mousePos - previousPos).magnitude * Time.deltaTime;

        if(velocity>minDistane)
        {
            circleColl.enabled = true;
        }
        else
        {
            circleColl.enabled = false;
        }

        previousPos = mousePos;
    }

    void StartCut()
    {
        isActive = true;
        previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        circleColl.enabled = false;
        currentTrail = Instantiate(trailPrefabs, transform);
    }

    void StopCut()
    {
        circleColl.enabled = false;
        isActive = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail, 2f);

    }
}

