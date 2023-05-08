using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CometCleanUP
{
    public class BlackHole : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Comet"))
            {
                collision.collider.isTrigger = true;
                collision.gameObject.GetComponent<Animator>().Play("CometFade");
                Destroy(collision.gameObject, 1f);
            }
        }
    }
}
