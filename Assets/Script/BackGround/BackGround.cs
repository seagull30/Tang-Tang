using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class BackGround : MonoBehaviour
{
    public event UnityAction<GameObject> OnPlayerBG;
    public event UnityAction PlayerOut;
    const float size = 10.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerBG.Invoke(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOut.Invoke();
        }
    }

    public void moveBG(GameObject obj)
    {
        if (Vector2.Distance(obj.transform.position, transform.position) > size * 1.5)
        {
            Vector2 dir = new Vector2(obj.transform.position.x - transform.position.x, obj.transform.position.y - transform.position.y).normalized;

            Debug.Log(dir);
            if (dir.x > 0.5 )
            {
                transform.position += new Vector3(size * 3, 0, 0);
            }
            else if (dir.x < -0.5)
            {
                transform.position += new Vector3(size * -3, 0, 0);
            }
            else if (dir.y > 0.5)
            {
                transform.position += new Vector3(0, size * 3, 0);
            }
            else if (dir.y < -0.5)
            {
                transform.position += new Vector3(0, size * -3, 0);
            }

        }

    }

}
