using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerPlayerTag : MonoBehaviour
{
    bool unLocked = false;
    Animator _Anim;

    // Start is called before the first frame update
    void Start()
    {
        _Anim = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("I have Entered the trigger");
            if (unLocked == true)
            {
                _Anim.SetTrigger("DoorTrigger");
            }
        }
    }

    public void Unlock()
    {
        unLocked = true;
        print(unLocked);
    }
}
