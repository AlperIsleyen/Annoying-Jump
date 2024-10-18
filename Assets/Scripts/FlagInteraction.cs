using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlagInteraction : MonoBehaviour
{
    public Transform flag;
    private float startYPosition; 
    public float moveDistance = 2f; 
    public float moveSpeed = 2f;
    public Color greenColor = new Color(0f, 0.5f, 0f);
    private SpriteRenderer flagRenderer;
    private bool hasExecuted = false;
    private void Start()
    {
        startYPosition = flag.position.y; 
        flagRenderer = flag.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasExecuted)
        {
            DataManager.Instance.lastCheckpoint = transform.position;

            StartCoroutine(MoveFlag());
            hasExecuted = true;
        }
    }

    private IEnumerator MoveFlag()
    {
        float targetYPosition = flag.position.y - moveDistance; 

        while (flag.position.y > targetYPosition)
        {
            float newYPosition = Mathf.MoveTowards(flag.position.y, targetYPosition, moveSpeed * Time.deltaTime);
            flag.position = new Vector2(flag.position.x, newYPosition);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        flagRenderer.color = greenColor;

        targetYPosition = startYPosition;

        while (flag.position.y < targetYPosition)
        {
            float newYPosition = Mathf.MoveTowards(flag.position.y, targetYPosition, moveSpeed * Time.deltaTime);
            flag.position = new Vector2(flag.position.x, newYPosition);
            yield return null;
        }
    }
}