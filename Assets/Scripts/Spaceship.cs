using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    float verticalInput, horizontalInput;
    float speed = 250;
    [SerializeField] Text text;
    bool gameOver = false;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void FixedUpdate()
    {
        float vertical = verticalInput * Time.fixedDeltaTime * speed;
        float horizontal = horizontalInput * Time.fixedDeltaTime * speed;
        Vector3 pos = transform.position;
        pos.y = 0;
        pos.x = Mathf.Clamp(pos.x + horizontal, -56, 56);
        pos.z = Mathf.Clamp(pos.z + vertical, -25, 25);
        transform.position = pos;
    }
    public void GameOver()
    {
        text.gameObject.SetActive(true);
        Time.timeScale = 0.1f;
        meshRenderer.enabled = false;
        gameOver = true;
    }
}
