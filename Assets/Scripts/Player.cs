using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;
    public int steps;
    bool isMoving;
    bool buttonIsPressed;

    public TMP_Text diceCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            diceCount.text = $"You rolled: {steps}";
            Debug.Log("You rolled: " + steps);
            StartCoroutine(Move());
        }
        if (buttonIsPressed && !isMoving)
        {
            steps = Random.Range(1, 7);
            diceCount.text = $"You rolled: {steps}";
            Debug.Log("You rolled: " + steps);
            StartCoroutine(Move());
            buttonIsPressed = false;
        }
    }

    public void ButtonPressed()
    {
        buttonIsPressed = true;
    }


    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        while(steps > 0)
        {
            routePosition++;
            //modulo resets route position to be zero whenever player hits the last node
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextNode = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextNode)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            //routePosition++;
        }

        isMoving = false;
    }

    bool MoveToNextNode(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, 8f * Time.deltaTime));
    }
}
