using System.Collections;
using UnityEngine;

public class VampirismButton : AbstractButton
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Player _player;

    private float _radius = 5f;
    private WaitForSeconds _waitForReload = new WaitForSeconds(3f);

    public override void OnClick()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_player.transform.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
                _vampirism.SetAbillity(enemy);
        }
    }

    public void Reload()
    {
        StartCoroutine(ReloadAbility());
    }

    private IEnumerator ReloadAbility()
    {
        Button.interactable = false;
        yield return _waitForReload;
        Button.interactable = true;
    }
}