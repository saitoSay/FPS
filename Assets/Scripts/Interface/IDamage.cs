public interface IDamage
{
    int HP { get; }
    int AttackPoint { get; }
    void Damage(int attackPoint);
}
