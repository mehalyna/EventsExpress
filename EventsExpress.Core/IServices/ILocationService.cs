﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventsExpress.Core.DTOs;
using NetTopologySuite.Geometries;

namespace EventsExpress.Core.IServices
{
    public interface ILocationService
    {
        Task<Guid> Create(LocationDTO locationDTO);

        Task<Guid> Edit(LocationDTO locationDTO);

        LocationDTO LocationById(Guid locationId);

        LocationDTO LocationByPoint(Point point);
    }
}