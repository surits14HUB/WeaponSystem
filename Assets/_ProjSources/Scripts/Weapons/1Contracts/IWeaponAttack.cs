namespace Weapons
{
    public interface IWeaponAttack
    {
        public void Attack();
    }

    [System.Serializable]
    public class AttackData
    {
        public int attackPower;
        public float waitTime;
    }
}