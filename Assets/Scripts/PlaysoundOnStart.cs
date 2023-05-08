using CometCleanUP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaysoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
