using UnityEngine;

public class PlayerHit : MonoBehaviour {
    private HUDHandler _HUDH;
    private float _health = 30f;

    void Start () {
        _HUDH = GameObject.Find("Canvas").GetComponent<HUDHandler>();
        _HUDH.health = _health;
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
    }
}
