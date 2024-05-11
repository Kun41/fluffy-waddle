using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //public AudioClip collectedClip;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Sækja RubyController hlutinn frá öðrum collider sem rekst á okkar collider
        PlayerMovement controller = other.GetComponent<PlayerMovement>();

        if (controller != null)
        {
            // Ef við erum á stigunum og heilsan er minni en hámarksheilsa
  
                // Breyta heilsu í RubyController og eyða fyrirbærinu sem safnað var
            controller.ChangeHealth(1);
            Destroy(gameObject);
        
            // Spila hljóðið sem safnað var
            //controller.PlaySound(collectedClip);

        }

    }
}
