using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfInteraction : MonoBehaviour, IInteractable
{
    public GameObject containedBook;

    public void Interact(){
        containedBook.SetActive(true);
    } 

    void Start()
    {
        containedBook.SetActive(false);
    }
}
