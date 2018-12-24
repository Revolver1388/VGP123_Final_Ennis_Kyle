using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

 
    public float forwardSpd = 16;
    public float sideSpd = 4;
    public float jumpForce = 6;
    public int jump;
    public int maxJump = 2;
    public weapons weapon;
    public weapons progWep;
    public float rotateSpd = 5;
    public float maxHealth = 20;
    public GameObject healthBar;
    public float currentHealth;
    public Animator anim;
    public bool isPaused = false;
    public GameObject computerUI;
    public GameObject computer;
    public GameObject computer2;
    public GameObject computer3;
    public GameObject light;
    public GameObject weapon1;
    public GameObject weapon2;
    public int weaponSelect = 0;
    public bool generator1 = false;
    public bool generator2 = false;
    public bool generator3 = false;


    public bool projectile = false;

    public static playerControls instance;
    private bool isGrounded = true;
    public bool endgame = false;
    private Rigidbody body;

    public bool win = false;

    Vector3 newlookat;

    void Start () {
        body = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        instance = this;

    }
    private void FixedUpdate()
    {
       
    }

    void Update() {
        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, .3f, .1f);
        Move();
        Jump();
        Rotate();
        shoot();
        winner();
        switchWeapon();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (projectile == true)
            {
                projectile = false;

            }
            else if (projectile == false)
            {
                projectile = true;
            }
        }
    }

    private void fixedUpdate()
    {
        Move();
    }

   
    void Move()
    {
        anim.SetFloat("dir x", Input.GetAxis("Horizontal"));
        Vector3 horizontal = Input.GetAxis("Horizontal") * sideSpd * transform.right * Time.fixedDeltaTime;
        anim.SetFloat("dir y", Input.GetAxis("Vertical"));
        Vector3 forwards = Input.GetAxis("Vertical") * forwardSpd * transform.forward * Time.fixedDeltaTime;

        
        body.AddForce(horizontal + forwards);
        transform.position += horizontal + forwards;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump < maxJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump++;
        }
    }

    void jumpPad()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * (jumpForce*10), ForceMode.Impulse);
            jump++;
        }

    void Rotate()
    {
        float look = Input.GetAxis("Mouse X") * rotateSpd * Time.deltaTime;
        newlookat = transform.position + transform.forward + look * transform.right;
        transform.LookAt(newlookat);
    }

    private void OnCollisionEnter(Collision collision)
    {   
        isGrounded = true;
        jump = 0;
    }

    void shoot()
    {
        if (projectile == true)
        {
            progWep.Fire(Input.GetButtonDown("Fire1"));
        }
        else if (projectile == false)
        {
            weapon.Fire(Input.GetButtonDown("Fire1"));
        }
    }

    public void damagePlayer(Vector3 damage)
    {
        currentHealth -= damage.magnitude;
        if (currentHealth <= 0)
        {
            endgame = true;
            //Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider c)
    {
         if (c.gameObject.tag == "computer")
        {
            if (generator1 == false)
            if (Input.GetKeyDown(KeyCode.E))
            {
                computerUI.SetActive(true);
                    generator1 = true;

                }
        }
        if (c.gameObject.tag == "computer2")
        {
            if (generator2 == false)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    computerUI.SetActive(true);
                    generator2 = true;
                }
        }
        if (c.gameObject.tag == "computer3")
        {
            if (generator3 == false)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    computerUI.SetActive(true);
                    generator3 = true;
                }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "computer")
        {
            computerUI.SetActive(false);
        }
            if (other.tag == "computer2")
        {
            computerUI.SetActive(false);
        }
        if (other.tag == "computer3")
        {
            computerUI.SetActive(false);
        }
    }

    void winner()
    {
        if(generator1 == true && generator2 == true && generator3 == true)
        {
            win = true;
            light.SetActive(true);
        }
    }

    void switchWeapon()
    { 
           if(projectile == false)
            {
                weapon1.SetActive(true);
                weapon2.SetActive(false);
            }
           else if (projectile == true)
            {
                weapon1.SetActive(false);
                weapon2.SetActive(true);
            }
        
    }
    //if (Vector3.Distance(player.transform.position, computer3.transform.position) < 2)
    //{
    //    if (generator3 == false)
    //    {
    //        computerUI.SetActive(false);
    //        generator3 = true;
    //    }
    //}
}


    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(newlookat, 0.2f);
    //}

