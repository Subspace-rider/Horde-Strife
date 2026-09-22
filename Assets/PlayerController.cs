using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region private variables
    private float moveSpeed = 10f;
    private float turnSpeed = 200f;
    private Rigidbody2D playerRB;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    private Vector3 movementInput;
    private Camera mainCamera;
    #endregion
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        #region camera based movement
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(upKey)) moveY += 1f;
        if (Input.GetKey(downKey)) moveY -= 1f;
        if (Input.GetKey(leftKey)) moveX -= 1f;
        if (Input.GetKey(rightKey)) moveX += 1f;

        Vector2 rawInput = new Vector2(moveX, moveY).normalized;

        if (mainCamera != null)
        {
            
            Vector3 camRight = mainCamera.transform.right;
            Vector3 camUp = mainCamera.transform.up;

            
            movementInput = (camRight * rawInput.x + camUp * rawInput.y);
        }
        else
        {
            movementInput = rawInput;
        }

        #endregion

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    void FixedUpdate()
    {
        #region Movement
        

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //
        }
        

        playerRB.linearVelocity = movementInput * moveSpeed;
        #endregion
    }
}
