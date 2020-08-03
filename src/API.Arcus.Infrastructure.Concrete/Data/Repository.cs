using System;
using System.Linq;
using System.Threading.Tasks;
using API.Arcus.Infrastructure.Repository;

namespace API.Arcus.Infrastructure.Concrete.Data
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		private readonly ArcusContext _context;

		public Repository(ArcusContext context)
		{
			_context = context;
		}

		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>();
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_context.Update(entity);
			await _context.SaveChangesAsync();

			return entity;
		}
	}
}