﻿using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface ISumService<T, TDto> where T : class where TDto : class
	{
	decimal Where(Expression<Func<T, decimal>> predicate);
	}
}
