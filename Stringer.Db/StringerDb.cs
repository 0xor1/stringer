using Common.Server.Auth;
using Microsoft.EntityFrameworkCore;
using ApiCounter = Stringer.Api.Counter.Counter;

namespace Stringer.Db;

public class StringerDb : DbContext, IAuthDb
{
    public StringerDb(DbContextOptions<StringerDb> opts)
        : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;

    public DbSet<FcmReg> FcmRegs { get; set; } = null!;
    public DbSet<Counter> Counters { get; set; } = null!;
}

[PrimaryKey(nameof(User))]
public class Counter
{
    public string User { get; set; }
    public uint Value { get; set; }

    public ApiCounter ToApi() => new(User, Value);
}
