﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using VRTK;

public class VRShop : MonoBehaviour
{

    public GameObject rightController;
    [SerializeField] private GameObject cannonMesh;
    [SerializeField] private GameObject gatlingMesh;
    [SerializeField] private GameObject missileLauncherMesh;
    [SerializeField] private GameObject punisherMesh;
    [SerializeField] private GameObject antiAirMesh;
    [SerializeField] private GameObject beamCannonMesh;
    [SerializeField] private GameObject shockwaveMesh;
    [SerializeField] private GameObject disruptionMesh;
    [SerializeField] private GameObject selectedTurret;

    public GameObject cannon;
    public GameObject gatling;
    public GameObject missileLauncher;
    public GameObject punisher;
    public GameObject antiAir;
    public GameObject beamCannon;
    public GameObject shockwave;
    public GameObject disruptor;

    private bool isCanonPurchased = true;
    private bool isGatlingPurchased = true;
    private bool isMissilePurchased = true;
    private bool isPunisherPurchased = true;
    private bool isAntiAirPurchased = true;
    private bool isBeamPurchased = true;
    private bool isShockwavePurchased = true;
    private bool isDisruptorPurchased = true;

    [SerializeField] private Sprite canonImage;
    [SerializeField] private Sprite gatlingImage;
    [SerializeField] private Sprite missileImage;
    [SerializeField] private Sprite punisherImage;
    [SerializeField] private Sprite antiAirImage;
    [SerializeField] private Sprite beamImage;
    [SerializeField] private Sprite shockwaveImage;
    [SerializeField] private Sprite disruptorImage;

    private ShopCosts costs;

    public VRTK_RadialMenu menu;
    private bool canPlace = false;

    private GameObject surfacePlotInstance;
    private VRTK_Pointer pointer;
    public GameObject invisibleCursor;

    public int coinBalance;

    // Use this for initialization
    void Start()
    {
        pointer = rightController.GetComponent<VRTK_Pointer>();
        costs = GetComponent<ShopCosts>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMenuItems()
    {
        menu.buttons[0].ButtonIcon = canonImage;
        menu.RegenerateButtons();

        menu.buttons[1].ButtonIcon = gatlingImage;
        menu.RegenerateButtons();

        menu.buttons[2].ButtonIcon = punisherImage;
        menu.RegenerateButtons();

        menu.buttons[3].ButtonIcon = missileImage;
        menu.RegenerateButtons();

        menu.buttons[4].ButtonIcon = antiAirImage;
        menu.RegenerateButtons();

        menu.buttons[5].ButtonIcon = beamImage;
        menu.RegenerateButtons();

        menu.buttons[6].ButtonIcon = shockwaveImage;
        menu.RegenerateButtons();

        menu.buttons[7].ButtonIcon = disruptorImage;
        menu.RegenerateButtons();
    }

    private void TogglePointer(GameObject g)
    {
        pointer.enabled = false;
        pointer.pointerRenderer.enabled = false;
        rightController.GetComponent<VRTK_BezierPointerRenderer>().customCursor = g;
        pointer.enabled = true;
        pointer.pointerRenderer.enabled = true;
    }

    private void ResetPointer()
    {
        pointer.enabled = false;
        pointer.pointerRenderer.enabled = false;
        rightController.GetComponent<VRTK_BezierPointerRenderer>().customCursor = invisibleCursor;
        pointer.enabled = true;
        pointer.pointerRenderer.enabled = true;
    }

    public void SetCursorCanon()
    {
        if (coinBalance >= costs.cannonCost)
        {
            TogglePointer(cannonMesh);
            selectedTurret = cannon;
            isCanonPurchased = true;
        } else
        {
            ResetPointer();
        }
    }

    public void SetCursorGatling()
    {
        if (coinBalance >= costs.gatlingCost)
        {
            TogglePointer(gatlingMesh);
            selectedTurret = gatling;
            isGatlingPurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorBeamCanon()
    {
        if (coinBalance >= costs.beamCannonCost)
        {
            TogglePointer(beamCannonMesh);
            selectedTurret = beamCannon;
            isBeamPurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorMissile()
    {
        if (coinBalance >= costs.missileLauncherCost)
        {
            TogglePointer(missileLauncherMesh);
            selectedTurret = missileLauncher;
            isMissilePurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorAntiAir()
    {
        if (coinBalance >= costs.antiAirCost)
        {
            TogglePointer(antiAirMesh);
            selectedTurret = antiAir;
            isAntiAirPurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorPunisher()
    {
        if (coinBalance >= costs.punisherCost)
        {
            TogglePointer(punisherMesh);
            selectedTurret = punisher;
            isPunisherPurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorShockwave()
    {
        if (coinBalance >= costs.shockwaveCost)
        {
            TogglePointer(shockwaveMesh);
            selectedTurret = shockwave;
            isShockwavePurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    public void SetCursorDisrupt()
    {
        if (coinBalance >= costs.disruptorCost)
        {
            TogglePointer(disruptionMesh);
            selectedTurret = disruptor;
            isDisruptorPurchased = true;
        }
        else
        {
            ResetPointer();
        }
    }

    private bool IsPurchased(GameObject g)
    {
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Cannon)
        {
            return isCanonPurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Gatling)
        {
            return isGatlingPurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Missile)
        {
            return isMissilePurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Beam)
        {
            return isBeamPurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Punisher)
        {
            return isPunisherPurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.AntiAir)
        {
            return isAntiAirPurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Shockwave)
        {
            return isShockwavePurchased;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Disruption)
        {
            return isDisruptorPurchased;
        }
        return false;
    }

    private void Purchase(GameObject g)
    {
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Cannon)
        {
            coinBalance -= costs.cannonCost;
            isCanonPurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Gatling)
        {
            coinBalance -= costs.gatlingCost;
            isGatlingPurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Missile)
        {
            coinBalance -= costs.missileLauncherCost;
            isMissilePurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Beam)
        {
            coinBalance -= costs.beamCannonCost;
            isBeamPurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Punisher)
        {
            coinBalance -= costs.punisherCost;
            isPunisherPurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.AntiAir)
        {
            coinBalance -= costs.antiAirCost;
            isAntiAirPurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Shockwave)
        {
            coinBalance -= costs.shockwaveCost;
            isShockwavePurchased = false;
        }
        if (g.GetComponent<TurretType>().turret == TurretType.TurretKind.Disruption)
        {
            coinBalance -= costs.disruptorCost;
            isDisruptorPurchased = false;
        }
    }


    public void SpawnTurret()
    {
        if (selectedTurret != null)
        {
            Debug.Log("Selected Turret" + selectedTurret.name);
            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
            GameObject[] antiairs = GameObject.FindGameObjectsWithTag("AntiAir");

            GameObject[] objs = turrets.Concat(antiairs).ToArray();
            surfacePlotInstance = new GameObject();
            surfacePlotInstance.transform.position = pointer.pointerRenderer.GetDestinationHit().point;

            if (objs.Length == 0) canPlace = true;
            foreach (GameObject g in objs)
            {
                Debug.Log("name " + g.name);
                if (Vector3.Distance(surfacePlotInstance.transform.position, g.transform.position) > 10)
                    canPlace = true;
                else
                    canPlace = false;
            }

            if (canPlace && IsPurchased(selectedTurret))
            {
                Vector3 newPos = new Vector3(surfacePlotInstance.transform.position.x, 0, surfacePlotInstance.transform.position.z);
                Instantiate(selectedTurret, newPos, Quaternion.identity);
                Purchase(selectedTurret);
                UpdateEnemyPaths();
            }
            else
            {
                Debug.Log("Turret too close");
            }
            Destroy(surfacePlotInstance);
        }
    }

    public void AddCoins(int amount)
    {
        coinBalance += amount;
    }

    private void UpdateEnemyPaths()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 || GameObject.FindGameObjectsWithTag("Aerial").Length > 0)
        {
            GameObject[] groundUnits = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] drones = GameObject.FindGameObjectsWithTag("Aerial");

            GameObject[] enemies = groundUnits.Concat(drones).ToArray();

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyAI>().UpdatePath();
            }
        }
    }
}
