using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, ICollectable
{
    [SerializeField]
    public PlayerData playerData;

    [SerializeField]
    private GameObject projetil;

    [SerializeField]
    private GameObject[] gunPointUpgrade;

    [SerializeField]
    private GameObject gunPoint;

    private Rigidbody2D rb;
    private Animator anim;
    private AnimationToStateMachine atsm;

    #region Upgrades
    private bool hasGunUpgrade;
    private bool hasSpeedUpgrade;
    private bool hasShield;

    public GameObject[] listaProjetil;

    #endregion

    public int Damage { get; private set; }
    private int maxHealth = 15;
    public int currentHealth { get; private set; }
    public int speed;
    public int score;

    private Vector3 workSpace;

    public bool alive;
    public bool endLine;
    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        atsm = GetComponentInChildren<AnimationToStateMachine>();

        canMove = true;
        hasGunUpgrade = false;
        hasSpeedUpgrade = false;
        currentHealth = maxHealth;
        alive = true;
        endLine = false;
        anim.SetBool("empty", false);
    }


    void Update()
    {
        playerData = GetComponentInChildren<PlayerData>();
        gunPoint = GameObject.Find("GunPoint");
        gunPointUpgrade[0] = GameObject.Find("GunPoint Upgrade 1");
        gunPointUpgrade[1] = GameObject.Find("GunPoint Upgrade 2");

        Damage = playerData.damage;
        speed = playerData.speed;

        workSpace = Vector3.zero;
        workSpace.x = Input.GetAxisRaw("Horizontal");
        workSpace.y = Input.GetAxisRaw("Vertical");

        if(workSpace != Vector3.zero && canMove)
        {
            if(!hasSpeedUpgrade)
            { 
                Move();
            }
            else if(hasSpeedUpgrade)
            {
                speed = playerData.speed + 10;
                Move();
            }
        }
        Shoot();
        if(currentHealth <= 0)
        {
            Die(); 
        }
    }
    private void Move()
    {

        rb.MovePosition(transform.position + workSpace * speed * Time.deltaTime);
    } 

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!hasGunUpgrade)
            {
                Instantiate(projetil, gunPoint.transform.position, Quaternion.identity);
            }
            else if(hasGunUpgrade)
            {
                Instantiate(projetil, gunPointUpgrade[0].transform.position, Quaternion.identity);
                Instantiate(projetil, gunPointUpgrade[1].transform.position, Quaternion.identity);
            }
        }
    }
    #region SetUpgrades
    public void SetGunUpgrade()
    {
        hasGunUpgrade = true;
        Invoke("SetGunUpgradeToFalse", 5f);
    }
    public void SetGunUpgradeToFalse()
    {
        hasGunUpgrade = false;
    }
    public void SetSpeedUpgrade()
    {
        Debug.Log("SetSpeed");
        hasSpeedUpgrade = true;
        Invoke("SetSpeedUpgradeToFalse", 5f);
    }
    public void SetSpeedUpgradeToFalse()
    {
        hasSpeedUpgrade = false;
    }
    #endregion
    public void TakeDamage(int damageAmount, bool empty)
    {
        Debug.Log(damageAmount);
        currentHealth -= damageAmount;
        anim.SetBool("empty", true);
        canMove = false;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void ItemValue(int value)
    {
        score += value; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemyyy")
        {
            Die();
        }
    }
    private void Die()
    {
        alive = false;
    }

    public void AnimationFinishTrigger()
    {
        anim.SetBool("empty", false);
        canMove = true;
    }
}
