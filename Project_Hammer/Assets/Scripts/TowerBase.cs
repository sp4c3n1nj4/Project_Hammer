using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerBase : MonoBehaviour
{
    ResourceManager manager;
    GameObject player;

    [SerializeField]
    private GameObject[] towers;
    [SerializeField]
    private GameObject uiPrefab;
    private GameObject ui;

    private KeyCode buildKey = KeyCode.E;
    private int towerIndex = 0;
    private int cost = 10;
    [SerializeField]
    private float interactDistance = 2;

    private void Awake()
    {
        manager = FindObjectOfType<ResourceManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        ui = Instantiate(uiPrefab, transform.position + Vector3.up * 0.3f, Quaternion.Euler(90, 0, 0), GameObject.FindGameObjectWithTag("WorldCanvas").transform);
    }

    private void OnEnable()
    {
        ui.GetComponent<TextMeshProUGUI>().text = buildKey.ToString();

        ui.SetActive(true);
    }

    private void Update()
    {
        if (CheckPlayerDistance() && Input.GetKeyDown(buildKey))
        {
            if (!(manager.gold >= cost))
            {
                Debug.LogError("insuficient gold");
                return;
            }

            OnInteract(towerIndex, cost);
        }
    }

    private void OnInteract(int towerIndex, int cost)
    {
        SpawnTower(towers[towerIndex]);

        manager.AddGold(- cost);

        ui.SetActive(false);
    }

    private void SpawnTower(GameObject tower)
    {
        Instantiate(tower, transform);
        gameObject.GetComponent<TowerBase>().enabled = false;
    }

    private bool CheckPlayerDistance()
    {
        bool b = false;
        var d = Vector3.Distance(transform.position, player.transform.position);

        if (d <= interactDistance)
            b = true;

        return b;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        //Gizmos.DrawSphere(transform.position, interactDistance);
    }
}
