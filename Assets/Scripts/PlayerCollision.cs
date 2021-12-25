using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Obstacle"))
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EngGame();
        }
    }
}
