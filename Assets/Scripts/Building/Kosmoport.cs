using UnityEngine;

public class Kosmoport : Building
{
    public override void Build()
    {
        GameObject.FindWithTag("GameOver").gameObject.SetActive(true);
    }
}