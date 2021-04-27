using AutoMapper;
using ITS.CORE.Repository;
using ITS.CORE.Services;
using ITS.CORE.UnitOfWork;
using ITS.SERVİCE.Mapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class SumService<T> : ISumService<T> where T : class 
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IGenericRepository<T> _genericRepository;
		public SumService(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
		{
			_unitOfWork = unitOfWork;
			_genericRepository = genericRepository;
		}
		public decimal Where(Expression<Func<T, decimal>> predicate)
		{
			decimal a =  _genericRepository.WhereToplam(predicate);
			return a;
		}

		public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> liste)
		{
			
			foreach (var i in liste)
			{
				var newEntity= ObjectMapper.MapperIslemleri.Map<T>(i);
				await _genericRepository.AddAsync(newEntity);
				await _unitOfWork.CommitAsync();
				
			}
			
			return liste;
		}

	}
}
