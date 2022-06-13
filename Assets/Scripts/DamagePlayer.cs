using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;
    public GameObject bloodParticles;
    public GameObject damageNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stats.defenseLevels[stats.currentLevel];
            if (totalDamage <= 0)
            {
                totalDamage = 1;
            }

            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);
            Instantiate(bloodParticles, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
            clone.GetComponent<DamageNumber>().damageText.color = Color.white;
        }
    }
}
