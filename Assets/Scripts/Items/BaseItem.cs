using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [SerializeField]
    private BaseItemDataSheet _baseItemDataSheet;

    public BaseItemDataSheet BaseItemDataSheet => _baseItemDataSheet;

    // Methods that all items *should* have. -Davoth //
    public void PickupItem()
    {

    }

    // Methods that all items *should* have. -Davoth //
    public void DropItem()
    {

    }
}
