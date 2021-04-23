using ITS.CORE.Dto;
using ITS.CORE.Repository;
using ITS.CORE.Services;
using ITS.CORE.UnitOfWork;
using ITS.SERVİCE.Mapper;
using ITS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.SERVİCE.Service
{
	public class ServicesGeneric<T, TDto> : IServiceGeneric<T, TDto> where T : class where TDto : class
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IGenericRepository<T> _genericRepository;
		public ServicesGeneric(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
		{
			_unitOfWork = unitOfWork;
			_genericRepository = genericRepository;
		}
		public async Task<Response<TDto>> AddAsync(TDto entity)
		{
			var NewEntity = ObjectMapper.MapperIslemleri.Map<T>(entity);//gelen dto yu entitye çevirme
			await _genericRepository.AddAsync(NewEntity);
			await _unitOfWork.CommitAsync();
			var NewDto = ObjectMapper.MapperIslemleri.Map<TDto>(NewEntity);//ıd veritabanına kaydedildi daha sonra cliente dto yu dönecem entity i dto ya çevirdim
			return Response<TDto>.Basarili(NewDto, 200);
		}

		public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
		{
			var Product = ObjectMapper.MapperIslemleri.Map<List<TDto>>(await _genericRepository.GetAllAsync());//gelen entityi maperladık
			return Response<IEnumerable<TDto>>.Basarili(Product, 200);//dto nesnesini geriye dönderdik
		}

		public async Task<Response<TDto>> GetIdAsync(int id)
		{
			var Product = await _genericRepository.GetAllByIdAsync(id);
			if (Product == null)
			{
				return Response<TDto>.Basarisiz("Id Bulunamadı", 404);
			}
			return Response<TDto>.Basarili(ObjectMapper.MapperIslemleri.Map<TDto>(Product), 200);
		}

		public async Task<Response<NoDataDto>> Remove(int id)
		{
			var IsExistEntity = await _genericRepository.GetAllByIdAsync(id);
			if (IsExistEntity == null)
			{
				return Response<NoDataDto>.Basarisiz("Belirtilen Ürün Bulunamadı", 404);
			}
			_genericRepository.Remove(IsExistEntity);
			await _unitOfWork.CommitAsync();
			return Response<NoDataDto>.Basarili(204);
		}

		public async Task<Response<NoDataDto>> Update(TDto entity, int id)
		{
			var IsExistEntity = await _genericRepository.GetAllByIdAsync(id);
			if (IsExistEntity == null)
			{
				return Response<NoDataDto>.Basarisiz("Ürün Bulunamadı", 400);
			}
			var Entity = ObjectMapper.MapperIslemleri.Map<T>(entity);
			_genericRepository.Update(Entity);
			await _unitOfWork.CommitAsync();
			return Response<NoDataDto>.Basarili(204);//gövde olmadığından 204 döner
		}

		public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<T, bool>> predicate)
		{
			//where(x=>x.id) //x func taki entity id ise bool değeri
			var list = _genericRepository.Where(predicate);
			return Response<IEnumerable<TDto>>.Basarili(ObjectMapper.MapperIslemleri.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
		}
	}
}
