using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region private variables
    private float moveSpeed = 180f;
    private float turnSpeed = 200f;
    private Rigidbody2D playerRB;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    #endregion
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 myInput = Vector3.zero;

        if(Input.GetKey(leftKey))
        {
            myInput = myInput + Vector3.left;
        }
        if(Input.GetKey(rightKey))
        {
            myInput = myInput + Vector3.right;
        }
        if(Input.GetKey(upKey))
        {
            myInput = myInput + Vector3.up;
        }
        if(Input.GetKey(downKey))
        {
            myInput = myInput + Vector3.down;
        }

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //
        }
        

        playerRB.AddForce(myInput*moveSpeed*Time.fixedDeltaTime);
        #endregion
    }
}
