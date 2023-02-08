namespace ShoppingBasket.Persistence.Repositories.Common;

public class GenericRepository<T>:IGenericRepository<T> where T:BaseEntity
{
    protected readonly ItemDbContext _context;

    public GenericRepository(ItemDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreatedAsync();
    }

    public async Task AddAsync(T entity)=> await _context.AddAsync(entity);
    

    public async Task<T?> GetAsync(int id)=>
    await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

    public async Task<List<T>> GetAllAsync()=>
        await _context.Set<T>().AsNoTracking().ToListAsync();

}