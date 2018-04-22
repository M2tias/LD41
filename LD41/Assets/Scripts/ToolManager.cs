// Date   : #CREATIONDATE#
// Project: #PROJECTNAME#
// Author : #AUTHOR#

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ToolManager : MonoBehaviour
{

    [SerializeField]
    private GameObject toolTarget;
    [SerializeField]
    private SpriteRenderer toolTargetRenderer;

    [SerializeField]
    private GridLayout gridLayout;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Image hoeImg;

    [SerializeField]
    private Image wateringCanImg;

    [SerializeField]
    private Image seedBagImg;

    [SerializeField]
    private Image hammerImg;

    [SerializeField]
    private Tilemap groundMap;
    [SerializeField]
    private Tilemap objectMap;

    private ToolTrigger pickable = null;
    private ToolTrigger picked = null;

    [SerializeField]
    private List<ToolTrigger> tools;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pz = player.transform.position;//Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        PlayerDirection dir = player.GetDir();
        if (dir == PlayerDirection.left)
        {
            pz = new Vector3(pz.x - 0.6f, pz.y, pz.z);
        }
        else if (dir == PlayerDirection.right)
        {
            pz = new Vector3(pz.x + 0.6f, pz.y, pz.z);
        }
        else if (dir == PlayerDirection.top)
        {
            pz = new Vector3(pz.x, pz.y + 0.6f, pz.z);
        }
        else if (dir == PlayerDirection.bottom)
        {
            pz = new Vector3(pz.x, pz.y - 0.6f, pz.z);
        }
        Vector3 pz2 = gridLayout.WorldToCell(pz);
        toolTarget.transform.position = new Vector3(pz2.x + 0.5f, pz2.y + 0.5f, 0f);

        TileBase targetedTile = groundMap.GetTile(new Vector3Int((int)pz2.x, (int)pz2.y, 0));
        TileBase objectTile = objectMap.GetTile(new Vector3Int((int)pz2.x, (int)pz2.y, 0));
        Debug.Log(targetedTile.name);

        if (picked == null)
        {
            hoeImg.enabled = false;
            wateringCanImg.enabled = false;
            seedBagImg.enabled = false;
            hammerImg.enabled = false;
            toolTargetRenderer.enabled = false;
        }
        else
        {
            toolTargetRenderer.enabled = true;
            if (picked.GetType() == ToolType.Hoe)
            {
                hoeImg.enabled = true;
                if(targetedTile.name == "static_2")
                {
                    toolTargetRenderer.color = Color.green;
                }
                else
                {
                    toolTargetRenderer.color = Color.red;
                }
            }
            else
            {
                hoeImg.enabled = false;
            }

            if (picked.GetType() == ToolType.WateringCan)
            {
                wateringCanImg.enabled = true;
                if (targetedTile.name == "static_2")
                {
                    toolTargetRenderer.color = Color.green;
                }
                else
                {
                    toolTargetRenderer.color = Color.red;
                }
            }
            else
            {
                wateringCanImg.enabled = false;
            }

            if (picked.GetType() == ToolType.SeedBag)
            {
                seedBagImg.enabled = true;
                if (targetedTile.name == "static_2")
                {
                    toolTargetRenderer.color = Color.green;
                }
                else
                {
                    toolTargetRenderer.color = Color.red;
                }
            }
            else
            {
                seedBagImg.enabled = false;
            }

            if (picked.GetType() == ToolType.Hammer)
            {
                hammerImg.enabled = true;
                if ((targetedTile.name == "static_0" || targetedTile.name == "static_1") && objectTile == null)
                {
                    toolTargetRenderer.color = Color.green;
                }
                else
                {
                    toolTargetRenderer.color = Color.red;
                }
            }
            else
            {
                hammerImg.enabled = false;
            }
        }
    }

    public void SetPickableTool(ToolTrigger toolTrigger)
    {
        pickable = toolTrigger;
    }

    public void TakeTool()
    {
        tools.ForEach(x => x.SetVisible(true));
        if (pickable)
        {
            pickable.SetVisible(false);
            picked = pickable;
        }
    }
}

public enum ToolType
{
    Hoe, WateringCan, SeedBag, Hammer
}