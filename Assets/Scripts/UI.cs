using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text HP;

    private int hpValue;

    PlayerMovement currentHP;

    void Start()
    {
        currentHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void updateHP()
    {
		 //HP.text = "HP: " + currentHP.HP;
    }

	void Update()
	{
		updateHP ();
	}
}
