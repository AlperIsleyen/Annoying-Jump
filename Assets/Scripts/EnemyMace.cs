using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMace : MonoBehaviour
{
    public float health;
    public float damage;
    public float maxHealth;
    bool colliderBusy = false;
    public Transform floatingText;
 
    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;  
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if(other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        Vector3 textPosition = transform.position + new Vector3(0.2f, 0f, 0f);
        textPosition.y += 2f;
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
        AmIDead();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }

}
