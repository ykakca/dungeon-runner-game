using UnityEngine;

public class Coins : MonoBehaviour
{
    public int points = 10;

    protected virtual void Collect()
    {
        //FindObjectOfType<GameManager>().CoinCollected(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Collect();
        }*/
        if (other.gameObject.CompareTag("Player")) {
            Collect();
        }
    }
}
