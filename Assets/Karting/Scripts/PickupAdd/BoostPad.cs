using UnityEngine;
using KartGame.KartSystems;

public class BoostPad : MonoBehaviour
{
    public float boostDuration = 2f;
    public float topSpeedBonus = 10f;
    public float accelerationBonus = 5f;
    public GameObject boostEffect;
    public AudioClip boostSound;

    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        // Find the kart, even if the collider is on a child object
        ArcadeKart kart = other.GetComponentInParent<ArcadeKart>();
        if (kart == null) return;

        ArcadeKart.StatPowerup boost = new ArcadeKart.StatPowerup();
        boost.PowerUpID = "BoostPad";
        boost.MaxTime = boostDuration;
        boost.modifiers.TopSpeed = topSpeedBonus;
        boost.modifiers.Acceleration = accelerationBonus;

        kart.AddPowerup(boost);

        if (boostEffect != null)
            Instantiate(boostEffect, transform.position, transform.rotation);

        if (boostSound != null)
            AudioSource.PlayClipAtPoint(boostSound, transform.position);
    }
}