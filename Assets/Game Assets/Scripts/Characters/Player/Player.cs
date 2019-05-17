using System.Collections.Generic;
using UnityEngine;

#region Player Class
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LifeCharacter))]
public class Player : MonoBehaviour {

    [Space (5)]
    [Header ("FORWARD MOVEMENT")]
    [Space (10)]
    [SerializeField] [Range (0, 255)] [Tooltip ("Velocidade frontal do player.")]
    private byte playerForwardSpeed = 0;

    [Space(5)]
    [Header ("SIDE MOVEMENT")]
    [Space(10)]
    [SerializeField] [Tooltip("Pai onde as posições laterais são guardadas.")]
    private Transform movementSideParent = null;

    [SerializeField] [Range(0, 10)] [Tooltip("Velocidade lateral do player.")]
    private float playerSideSpeed = 0;

    [SerializeField] [Tooltip("Lista de input de movimentos laterais. \nComeçando do movimento lateral esquerdo com (0).")]
    private List<InputMove> inputMoveList = new List<InputMove>(2);

    [Space(10)]
    [Header("JUMP EDITION")]
    [Space(5)]
    [SerializeField] [Range(0, 255)] [Tooltip("Velocidade frontal do player.")]
    private float jumpForce = 2.5f;

    [SerializeField] [Tooltip("Velocidade frontal do player.")]
    private KeyCode inputJump = KeyCode.W;

    [Space(10)]
    [Header("COLLISION EDITION")]
    [SerializeField] [Tooltip("Tag de colisão com o chão.")]
    private string groundTag = "Ground";

    Animator anim;
    Rigidbody rb;
    private bool canJump = true;
    private bool canMove = true;
    private sbyte indexSideMovement = 1;

    #region MonoBehaviour
    
    #region Initialization
    private void Awake() {
        this.anim = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        this.canJump = true;
        this.indexSideMovement = 1;
    }
    #endregion

    #region Updates
    private void Update() {
        if (this.canMove) {
            this.InputSideMovement();
            this.MovementForwardPlayer();
        }
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(this.inputJump) && this.canJump == true)
            this.JumpPlayer();
    }
    #endregion

    #region Coliisions
    private void OnCollisionStay(Collision col) {
        this.GroundCheck(col);
    }
    #endregion

    #endregion

    //<<----------------------->>\\

    #region Movement Forward Player
    /// <summary>
    /// Movementa o personagem para frente.
    /// </summary>
    private void MovementForwardPlayer () {
        Vector3 speedMove = Vector3.forward * this.playerForwardSpeed * Time.deltaTime;
        this.transform.Translate(speedMove);
    }
    #endregion    

    //<<----------------------->>\\

    #region Input Side Movement
    /// <summary>
    /// Inputs de movimento lateral do player.
    /// </summary>
    void InputSideMovement () {
        if (Input.GetKeyDown(this.inputMoveList[0].inputSide))
            this.indexSideMovement--;
        else if (Input.GetKeyDown(this.inputMoveList[1].inputSide))
            this.indexSideMovement++;

        this.indexSideMovement = (sbyte)Mathf.Clamp(this.indexSideMovement, 0, 2);
        this.MovementSidePlayer();
    }
    #endregion

    #region Movement Side Player
    /// <summary>
    /// Movementa o personagem entre os lados.
    /// </summary>
    private void MovementSidePlayer () {
        float newPosX = this.movementSideParent.GetChild(this.indexSideMovement).transform.position.x;
        Vector3 newSidePos = new Vector3(newPosX, this.transform.position.y, this.transform.position.z);
        Vector3 smoothMove = Vector3.MoveTowards(this.transform.position, newSidePos, (float)(this.playerSideSpeed / 20));

        this.transform.position = smoothMove;
    }
    #endregion

    //<<----------------------->>\\

    #region Jump Player
    private void JumpPlayer() {
        this.canJump = false;

        this.SetBoolAnimation("Jump", !this.canJump);

        Vector3 jump = Vector3.up * this.jumpForce * 50 * Time.fixedDeltaTime;
        this.rb.AddForce(jump, ForceMode.Impulse);
    }
    #endregion

    #region Ground Check
    /// <summary>
    /// Verifica se está colidindo com o chão.
    /// </summary>
    /// <param name="col">Collision do chão.</param>
    private void GroundCheck (Collision col) {
        if (col.collider.CompareTag (this.groundTag)) {
            this.canJump = true;
            this.SetBoolAnimation("Jump", !this.canJump);
        }
    }
    #endregion

    public void CanMove (bool canMove) {
        this.canMove = canMove;
    }

    public void SetBoolAnimation (string NameParameter, bool activeAnim) {
        if (anim)
            anim.SetBool(NameParameter, activeAnim);
    }
}
#endregion

#region Input Move Class
[System.Serializable]
public class InputMove {
    [Tooltip("Nome do input.")] public string InputName;
    [Tooltip("Input de movemento lateral.")] public KeyCode inputSide;
}
#endregion