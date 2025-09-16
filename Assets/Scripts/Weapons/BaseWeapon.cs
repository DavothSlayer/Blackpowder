public class BaseWeapon : BaseItem
{
    public BaseWeaponDataSheet WeaponData => (BaseWeaponDataSheet)BaseItemDataSheet;

    // For things like shooting a weapon, or swinging an axe. -Davoth //
    public virtual void PrimaryFunction()
    {

    }

    // For things like aiming a weapon, or perhaps throwing an axe. -Davoth //
    public virtual void SecondaryFunction()
    {

    }
}
