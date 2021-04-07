using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public bool wasHit = false;

    private float _enemyCooldown = 0f;

    void Update () {

        _enemyCooldown -= Time.deltaTime;

        if (_enemyCooldown <= 0) {
            wasHit = false;
        }
    }

    
    public void stunned () {

        wasHit = true;
        _enemyCooldown = 5f;
    }
}
