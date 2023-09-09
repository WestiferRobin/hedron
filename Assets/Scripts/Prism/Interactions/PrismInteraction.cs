using UnityEngine;
using System.Collections;

public class PrismInteraction : MonoBehaviour
{
    private PrismCore core;
    public PrismCore GetCore() => core;

    private PrismCombat combat;
    public PrismCombat GetCombat() => combat;

    private PrismSocial social;
    public PrismSocial GetSocial() => social;

    private PrismNeeds needs;
    public PrismNeeds GetNeeds() => needs;

    private PrismMovement movement;
    public PrismMovement GetMovement() => movement;

    private PrismUI ui;

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

