using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControlAnimation : MonoBehaviour
{
    public GameObject anchorGameObject;
    public string weightsSelected;
    public AudioSource audioSource;
    public GrabbableObject grabOb;

    void Start()
    {
        grabOb = gameObject.GetComponent<GrabbableObject>();
    }

    void Update()
    {
        if (grabOb.getWandPointing())
        {
            DoOnHover();
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("WeightsSelected"))
        {
            weightsSelected = "";
            PlayerPrefs.SetString("WeightsSelected", weightsSelected);
        }
        else
        {
            PlayerPrefs.SetString("WeightsSelected", "");
        }
    }
    private void DoOnHover()
    {
        if (CAVE2.GetButtonDown(CAVE2.Button.Button3))
        {
            this.GetComponent<CapsuleCollider>().enabled = false;
            audioSource.Play();

            print("Play The Animaton");
            this.GetComponent<Animator>().SetTrigger("Play");
            weightsSelected = PlayerPrefs.GetString("WeightsSelected");
            //gameObject.GetComponent<AudioSource>().Play();

            string[] weightsSelectedArray = weightsSelected.Split('|');
            if (Array.FindIndex(weightsSelectedArray, e => e == this.gameObject.name) == -1)
            {
                if (weightsSelected.Length > 0)
                {
                    weightsSelected += "|" + this.gameObject.name;
                }
                else if (weightsSelected.Length == 0)
                {
                    weightsSelected += this.gameObject.name;
                }
            }
            PlayerPrefs.SetString("WeightsSelected", weightsSelected);
            print("Weights Selected:" + weightsSelected);
            if (weightsSelected.Split('|').Length == 2)
            {
                StartCoroutine(DropTheAnchor());
            }
        }
    }
    private IEnumerator DropTheAnchor()
    {
        if (this.gameObject.name.Contains("Kilogram"))
        {
            yield return new WaitForSeconds(6.0f);
        }
        else if (this.gameObject.name.Contains("Pounds"))
        {
            yield return new WaitForSeconds(3.0f);
        }
        anchorGameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}

