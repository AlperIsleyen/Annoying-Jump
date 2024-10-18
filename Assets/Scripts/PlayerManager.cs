using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    Transform muzzle;
    public Transform star, floatingText, bloodParticle;
    public float bulletSpeed;
    public Slider slider;
    public Vector2 respawnPoint;
    public GameObject player;

    public Button starButton;

    private void Awake()
    {
        CheckPointCheck();
    }

    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckPointCheck()
    {
        if(DataManager.Instance.lastCheckpoint == Vector2.zero) {
            respawnPoint = transform.position;
        }
        else
        {
            player.transform.position = DataManager.Instance.lastCheckpoint;
        }

    }

    public void StarButton()
    {
        ShootBullet();
    }

    public void GetHeal(float heal)
    {
        health += heal;
        if (health > 100)
        {
            health = 100;
        }
        slider.value = health;
    }
    public void GetDamage(float damage)
    {
        Vector3 textPosition = transform.position + new Vector3(0.2f, 0f, 0f);
        textPosition.y += 1.5f;
        textPosition.x -= 1f;

        Instantiate(floatingText, textPosition, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead(player);
    }
    void AmIDead(GameObject player)
    {
        if (health <= 0)
        {
            player.SetActive(false);
            if (!IsFallingDeath())
            {
                Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            }

            StartCoroutine(Wait(3f));

            transform.position = respawnPoint;
            GetHeal(100);
            player.SetActive(true);

        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(star, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathRegion"))
        {
            GetDamage(100);
            AmIDead(player);
        }
        else if (collision.CompareTag("Flag"))
        {
            respawnPoint = transform.position;
        }
    }
    bool IsFallingDeath()
    {
        return transform.position.y < -10f;
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
