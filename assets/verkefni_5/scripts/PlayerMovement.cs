using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public Animator animator; // animator variable
    public static int stig; // integer variable fyrir stig
    private TextMeshProUGUI countText; // variable fyrir fox>canvas>text
    public CharacterController2D controller; // eg er ad nota brackeys script fyrir controller
    public float runSpeed = 40f; // hradi til ad hlaupa
    float HorizontalMove = 0f; // float fyrir x movement
    bool jump = false; // ef stilt a ja refur hoppar
    public bool facingright = true; // variable til að vita ef playerinn er að facea i hægri
    public Transform shootingPoint; // point sem bullets kemur fra
    public GameObject bulletPrefab; // variable fyrir bullet

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // rigidbody
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>(); // gerir instance af stig texti
        stig = 0; // setta stig i 0 utaf þvi þetta er start
        SetCountText(); // kallar a function fyrir nedan sem settar textid sem ("Stig: " + stig, nuna er þad "Stig: 0")
    }

    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // fæ axis/lyklabord og svo margfaldar með run speed, t.d ef axis er 1(hægri) þa er horizontal move 40 ef 0(vinstri) þa er -40
        animator.SetFloat("Speed",Mathf.Abs(HorizontalMove)); // settar float paramater i animator sem Horizontal move og abs er til þess ad tala verdur alltaf jakvætt
        if(Input.GetAxisRaw("Horizontal")== 1)
        {
            facingright = true;  // checkar ef playerinn er ad facea hægri eða vinstri og svo stillar facingright bool i true eda false
        }
        if(Input.GetAxisRaw("Horizontal")==-1)
        {
            facingright = false;
        }
        if (Input.GetButtonDown("Jump")) // ef space er yttid þa settur jump i true
        {
            jump = true; 
            animator.SetBool("IsJumping",true); // settur boolean i animator fyrir jumping i true
        }
        if (stig < 0)
        {
            SceneManager.LoadScene(0); // ef stig er undir 0 þa playerin deyr og scena er 0
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bulletPrefab,shootingPoint.position,transform.rotation); //skota ef c er ytt
        }

    }
    public void OnLanding () // function sem vid notum i player controller eftir brackeys
    {
        animator.SetBool("IsJumping",false); // settur boolean i animator fyrir jumping i false

    }
    void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime,false,jump); // controller er script fra brackeys og argument er (horizontal*fixed delta, crouching, jumping)
        jump = false;  //þegar charactarin hoppar þa er jump = false svo þu þarft að ytta space aftur ef þu vil hoppa
        
    }
        private void SetCountText()
    {
        countText.text = "Stig: " + stig.ToString(); // settar textid sem Stig:stig variable(stig sem vid erum med nuna)
    }
    public void ChangeHealth(int amount) // changehealth function fra ruby2d
    {
        stig = stig+amount;
        SetCountText();
    }
    


}
