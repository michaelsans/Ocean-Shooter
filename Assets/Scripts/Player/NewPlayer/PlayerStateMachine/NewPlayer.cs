using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour, IDamageable
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerHurtState EmptyState { get; private set; }

    public int currentHealth;
    private int maxHealth = 15;
    [SerializeField]
    private NewPlayerData playerData;
    private GameObject gunPoint;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB2D { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Shoot
    public float nextFire = .3f;
    public float fireRate = .3f;
    public int damage;
    private bool canShoot;
    #endregion

    #region Bolhas
    [SerializeField] Transform bolhasEsquerda;

    [SerializeField] Transform bolhasDireita;

    [SerializeField] GameObject bolhas;
    private float randy;
    private float randx;
    public float nextBubble = .3f;
    public float bubbleRate = .3f;
    #endregion

    #region Other Variables
    private Vector2 workSpace;
    public int score { get; private set; }
    public bool alive { get; private set; }
    public bool endLine { get; private set; }

    public bool isInvincible;
    private LootMenu loot;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        loot = GameObject.Find("Canvas").GetComponent<LootMenu>();
        Core = GetComponentInChildren<Core>();
        gunPoint = GameObject.Find("gunPoint");
        currentHealth = maxHealth;
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        HurtState = new PlayerHurtState(this, StateMachine, playerData, "hurt");
        EmptyState = new PlayerHurtState(this, StateMachine, playerData, "empty");
        damage = playerData.Damage;
        damage = playerData.Damage;

        alive = true;
        endLine = false;
        isInvincible = false;
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        canShoot = true;
        StateMachine.Initialize(IdleState);
        NewAudioManager.instance.Play("motor");
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();

        if (Time.time > nextFire && fireRate > 0 && canShoot)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
        if (StateMachine.CurrentState != EmptyState)
        {
            if ((Core.Movements.RB2D.velocity.y != 0) || (Core.Movements.RB2D.velocity.x != 0))      
                bubbleRate = 0.01f;
            
            else
                bubbleRate = 0.1f;
                
            
            if (Time.time > nextBubble && bubbleRate > 0)
            {
                nextBubble = Time.time + bubbleRate;
                SpawnBubbles();
            }
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other functions

    public void TakeDamage(int amount, bool empty)
    {

        if(!isInvincible)
        {
            FindObjectOfType<NewAudioManager>().Play("impact");
            Debug.Log(amount + " Damage Taken");
            currentHealth -= amount;
            
            if (empty)
            {
                Debug.Log("empty");
                StateMachine.ChangeState(EmptyState);
                
            }
            else
            {
                Debug.Log("hurt");
                StateMachine.ChangeState(HurtState);
                Core.Movements.SetVelocity(10, new Vector2(-45, -45), 1);
            }
            if (currentHealth <= 0)
            {
                alive = false;
                PlayerManager.playerManagerInstance.SavePlayer();
                //Die();
            }
        }
        loot.SetHealthBar();
    }

    public void Shoot()
    {
        Instantiate(playerData.projetil, gunPoint.transform.position, Quaternion.identity);
    }

    public void SetCanShoot()
    {
        canShoot = !canShoot;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();


    void SpawnBubbles()
    {
        randy = Random.Range(0.1f, 0.5f);
        randx = Random.Range(-.5f, .5f);
        Instantiate(bolhas, new Vector3(bolhasEsquerda.transform.position.x + randx, bolhasEsquerda.transform.position.y - randy, 0f), Quaternion.identity);
        Instantiate(bolhas, new Vector3(bolhasDireita.transform.position.x + randx, bolhasDireita.transform.position.y - randy, 0f), Quaternion.identity);
    }
    #endregion
}
