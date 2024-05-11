using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject PointA; // Punktur A sem óvinurinn fer til
    public GameObject PointB; // Punktur B sem óvinurinn fer til
    private Rigidbody2D rb; // Rigidbody komponent sem stjórnar hreyfingu
    private Transform currentPoint; // Núverandi punktur sem óvinurinn er á leiðinni að
    public float speed; // Hraði óvinarins
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform; // Byrjunarpunkturinn er settur sem B punkturinn
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed,0);  // Hreyfing áfram ef núverandi punktur er B
        }
        else
        {
            rb.velocity = new Vector2(-speed,0); // Hreyfing afturábak ef núverandi punktur er ekki B
        }
        if(Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {   
            flip();
            currentPoint = PointA.transform; // Skipta um punkt ef núverandi er B og óvinurinn er nálægt
        }    
        if(Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform; // Skipta um punkt ef núverandi er A og óvinurinn er nálægt
        }
    }   
    
    // Fall sem snýr við óvin
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
     // Fall sem teiknar línur milli punktanna a,b og sýnir þá sem sphere
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position,0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position,0.5f);
        Gizmos.DrawLine(PointA.transform.position,PointB.transform.position);
    }
    void OnCollisionEnter2D(Collision2D other)
     // Fall sem keyrir þegar óvinur rekst á leikmann
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.ChangeHealth(-1);  // Mínusar stig leikmannsins ef rekist er á hann
        }
    }
}
