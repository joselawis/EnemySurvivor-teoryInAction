using Assets.Lawis.Factory;

public class EnemyFactory : GenericFactory<AEnemy>
{
    public EnemyFactory(GenericFactoryConfiguration<AEnemy> itemConfiguration) : base(itemConfiguration)
    {
    }
}
