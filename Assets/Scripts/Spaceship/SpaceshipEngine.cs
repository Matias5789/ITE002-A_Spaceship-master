using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour, IGunController, IMovementController
{
    public Projectile projectilePrefab;
    public Spaceship spaceship;

    public void OnEnable()
    {
        spaceship.SetMovementCotroller(this);
        spaceship.SetGunController(this);
    }

    public void Update()
    {
        if (Input.GetButton("Horizontal")){
            spaceship.MoveHorizontally(Input.GetAxis("Horizontal"));
        }
        if (Input.GetButton("Vertical")){
            spaceship.MoveVerticaly(Input.GetAxis("Vertical"));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            spaceship.applyFire();
        }
    }
    public void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    public void MoveHorizontally(float x)
    {
        var horizontal = Time.deltaTime * x;
        transform.Translate(new Vector3(horizontal, 0));
    }

    public void MoveVerticaly(float y)
    {
        var vertical = Time.deltaTime * y;
        transform.Translate(new Vector3(0, vertical));
    } 
}