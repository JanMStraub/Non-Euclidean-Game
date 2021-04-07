using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public bool _wasHit = false;
    private float _enemyCooldown = 0f;

    void Update () {
        _enemyCooldown -= Time.deltaTime;

        if (_enemyCooldown <= 0) {
            _wasHit = false;
        }
    }
    public void stunned () {
        _wasHit = true;
        _enemyCooldown = 5f;
    }
}
