// Date   : #CREATIONDATE#
// Project: #PROJECTNAME#
// Author : #AUTHOR#

using UnityEngine;
using System.Collections;

public class ToolTrigger : MonoBehaviour
{
    [SerializeField]
    private ToolType type;

    [SerializeField]
    private ToolManager toolMngr;

    [SerializeField]
    private SpriteRenderer toolSprite;

    private bool triggered;

    private bool visible = true;

    void Start()
    {

    }

    void Update()
    {
        toolSprite.enabled = visible;
    }

    public ToolType GetType()
    {
        return type;
    }

    public bool IsTriggered()
    {
        return triggered;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("moi");
        if (other.transform.tag == "Player")
        {
            triggered = true;
            toolMngr.SetPickableTool(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            triggered = false;
        }
    }

    public void SetVisible(bool visible)
    {
        this.visible = visible;
    }
}
