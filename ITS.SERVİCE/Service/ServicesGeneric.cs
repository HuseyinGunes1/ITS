using ITS.CORE.Dto;
using ITS.CORE.Repository;
using ITS.CORE.Services;
using ITS.CORE.UnitOfWork;
using ITS.DATA.Context;
using ITS.SERVİCE.Mapper;
using ITS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public async Task<T> AddAsync(TDto entity)
		{
			var NewEntity = ObjectMapper.MapperIslemleri.Map<T>(entity);//gelen dto yu entitye çevirme
			await _genericRepository.AddAsync(NewEntity);
			await _unitOfWork.CommitAsync();
			//var NewDto = ObjectMapper.MapperIslemleri.Map<TDto>(NewEntity);//ıd veritabanına kaydedildi daha sonra cliente dto yu dönecem entity i dto ya çevirdim
			return NewEntity;
		}

		public async Task<IEnumerable<TDto>> AddAllAsync(IEnumerable<TDto> liste)
		{

			foreach (var i in liste)
			{
				var newEntity = ObjectMapper.MapperIslemleri.Map<T>(i);
				await _genericRepository.AddAsync(newEntity);
				await _unitOfWork.CommitAsync();


			}


			return liste;
		}

		public async Task<IEnumerable<TDto>> GetAllAsync()
		{
			var Product = ObjectMapper.MapperIslemleri.Map<List<TDto>>(await _genericRepository.GetAllAsync());//gelen entityi maperladık
			
			return Product;//dto nesnesini geriye dönderdik
		}
		public async Task<IEnumerable<T>> GetAllAsync2()
		{
			var Product = await _genericRepository.GetAllAsync();

			return Product;
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

		public  IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
		{
			//where(x=>x.id) //x func taki entity id ise bool değeri
			var list = _genericRepository.Where(predicate);
			return list.ToList();
		}


	}
}
