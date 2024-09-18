using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private Bounds _cameraBounds;
    public Projectile projectilePrefab;
    public float speed = 5f;

    void Start()
    {
        var heigth = Camera.main.orthographicSize * 2f;
        var width = heigth * Camera.main.aspect;

        var size = new Vector3(width, heigth);

        _cameraBounds = new Bounds(Vector3.zero, size);
    }

    void Update()
    {
        ApplyMovement();
        FireProjectile();
    }

    void LateUpdate()
    {
        var newPosition = transform.position;

        newPosition.x = Mathf.Clamp(transform.position.x,
            _cameraBounds.min.x + 0.5f, _cameraBounds.max.x - 0.5f);

        newPosition.y = Mathf.Clamp(transform.position.y,
            _cameraBounds.min.y + 0.5f, _cameraBounds.max.y - 0.5f);

        transform.position = newPosition;
    }
    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    void ApplyMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }
}
