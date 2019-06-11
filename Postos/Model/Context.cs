using System;

public class Context : DbContext
{
    private SingletonContext() { }

    public Context() : base("Posto-Api")
	{
	}

    public DbSet<EntidadeBase> Entidade { get; set; }
    public DbSet<Posto> Posto { get; set; }
}
