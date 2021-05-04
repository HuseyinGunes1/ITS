using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface ISumService<T> where T : class 
	{
	
    public  Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> liste);
		
	}
}
