using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed=30;
    private PlayerControl playercontrolscript;
    private float leftbound=-10.0f;
    // Start is called before the first frame update
    void Start()
    {
        playercontrolscript = GameObject.Find("player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrolscript.gameover == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftbound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
