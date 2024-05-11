using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Tenging við PlayerMovement skriftuna
    private PlayerMovement playerMovement;
    // Hraði á hreyfingu skotsins
    public float speed;
    // Rigidbody komponentinn
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         // Setja hreyfingu á skotið í byrjun
        rb.velocity = DetermineDirection() * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         // Ef skotið rekst á óvin
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            // Eyða óvin
            Destroy(collision.gameObject);
        }
         // Ef skotið rekst ekki á leikmann
        if (collision.gameObject.layer != LayerMask.NameToLayer("player"))
        {
            Destroy(gameObject);
        }
        // Eyða skotinu
        Destroy(gameObject);
    }
    Vector2 DetermineDirection()
    {
        // Fall sem ákvarðar áttina sem skotið á að fara í
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

         // Sækja PlayerMovement skriftuna frá leikmanni
        if (playerMovement.facingright)
        {
            // Ef horft er til hægri, skjóta til hægri
            return transform.right;
        }
        else
        {
           // Ef horft er til vinstri, skjóta til vinstri
            return -transform.right;
        }
    }
}
