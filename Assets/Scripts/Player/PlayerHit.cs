using UnityEngine;

public class PlayerHit : MonoBehaviour {

    private HUDHandler _HUDH;

    private GameOverMenu _GOM;

    private float _health = 30f;

    void Start () {

        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
        _HUDH.health = _health;

        _GOM = GameObject.Find("Canvas").GetComponent<GameOverMenu>();
    }


    public void TakeDamage (float amount) {

        _health -= amount;
        _HUDH.health -= amount;
        if (_health <= 0f) {
            Die();
        }
    }


    void Die () {
        
        Destroy(gameObject);
        _GOM.PlayerIsAlive = false;
    }
}
