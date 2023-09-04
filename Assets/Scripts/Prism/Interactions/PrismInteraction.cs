using UnityEngine;
using System.Collections;

public class PrismInteraction : MonoBehaviour
{
    public PrismCore core;
    public PrismCombat combat;
    public PrismSocial social;
    public PrismNeeds needs;
    public PrismMovement movement;
    public PrismUI ui;

    // Use this for initialization
    void Start()
	{
        core = core != null ? core : GetComponent<PrismCore>();
        combat = combat != null ? combat : GetComponent<PrismCombat>();
        social = social != null ? social : GetComponent<PrismSocial>();
        needs = needs != null ? needs : GetComponent<PrismNeeds>();
        movement = movement != null ? movement : GetComponent<PrismMovement>();
        ui = ui != null ? ui : GetComponent<PrismUI>();
	}

	// Update is called once per frame
	void Update()
	{
			
	}
}

