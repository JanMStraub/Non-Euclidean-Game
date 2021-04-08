using UnityEngine;

public class PlayerHit : MonoBehaviour {

    private HUDHandler _HUDH;

    private GameOverMenu _GOM;

    private float _health = 50f;

    void Start () {

        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
        _HUDH.health = _health;

        _GOM = GameObject.Find("Canvas").GetComponent<GameOverMenu>();
    }


    // If enemy hits the player his health is reduced
    public void TakeDamage (float amount) {

        _health -= amount;
        _HUDH.health -= amount;
        if (_health <= 0f) {
            Die();
        }
    }


    // If player dies he is destroyed and the game over screen is displayed
    void Die () {
        
        Destroy(gameObject);
        _GOM.PlayerIsAlive = false;
    }
}
