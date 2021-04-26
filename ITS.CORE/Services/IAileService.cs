﻿using ITS.CORE.Dto;
using ITS.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITS.CORE.Services
{
	public interface IAileService
	{
		public Task<Response<CreateAileDto>> AddIsAsync(CreateAileDto aile);
		
	}
}
