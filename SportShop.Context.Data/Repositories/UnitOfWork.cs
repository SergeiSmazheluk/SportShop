﻿using SportShop.Domain.Interfaces;

namespace SportShop.Context.Data.Repositories
{
	internal sealed class UnitOfWork : IUnitOfWork
	{
		private readonly RepositoryDbContext _dbContext;

		public UnitOfWork(RepositoryDbContext dbContext) => _dbContext = dbContext;

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
			_dbContext.SaveChangesAsync(cancellationToken);
	}
}
