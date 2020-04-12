using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PasswordScript : MonoBehaviour
{
    [SerializeField]
    private InputField pass;
    void Start()
    {
        //pass.ShortcutsEnabled = false;
    }
}
