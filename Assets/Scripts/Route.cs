using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    void Start()
    {
        FillNodes();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentNode = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 firstNode = childNodeList[0].position;
                Vector3 lastNode = childNodeList[39].position;
                Vector3 previousNode = childNodeList[i - 1].position;
                Gizmos.DrawLine(previousNode, currentNode);
                Gizmos.DrawLine(lastNode, firstNode);
            }
        }
    }

    void FillNodes()
    {
        childNodeList.Clear();
        childObjects = GetComponentsInChildren<Transform>();

        foreach (Transform child in childObjects)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }
}
