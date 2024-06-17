using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 4.0f;
    float h, v;
    public GameObject FinUI;
    public Text StageTxt;
    public GameObject MyCamera;
    Vector3 respawnPoint = new Vector3(10f+(stage*100),2f,-10f);
    public static int stage = 0;

    // Start is called before the first frame update
    void Start()
    {
        StageTxt.text = "현재 스테이지: " + (stage + 1);
    }

    // Update is called once per frame
    void Update()
    {
        StageTxt.text = "현재 스테이지: " + (stage + 1);
        respawnPoint = new Vector3(10f + (stage * 100), 2f, -10f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // 가로축
        v = Input.GetAxis("Vertical");          // 세로축

        // Point 2.
        transform.position += new Vector3(-h, 0, -v) * Speed * Time.deltaTime;
    }

    void Respawn()
    {
        FinUI.gameObject.SetActive(false);
        gameObject.transform.position = respawnPoint;
        MyCamera.transform.position = new Vector3(0 + (stage * 100), 20, 12);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Finish")
        {
            FinUI.gameObject.SetActive(true);
            stage++;
        }
        if (col.gameObject.tag == "Respawn")
        {
            Respawn();
        }
    }
}
