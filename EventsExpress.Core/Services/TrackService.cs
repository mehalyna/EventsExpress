﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventsExpress.Core.DTOs;
using EventsExpress.Core.IServices;
using EventsExpress.Db.EF;
using EventsExpress.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsExpress.Core.Services
{
    public class TrackService : BaseService<ChangeInfo>, ITrackService
    {
        public TrackService(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<ChangeInfo> GetChangeInfoByScheduleIdAsync(Guid id)
        {
            return await Context.ChangeInfos
                .FromSqlRaw(
                    @"SELECT * FROM ChangeInfos WHERE EntityName = 'EventSchedule' AND JSON_VALUE(EntityKeys, '$.Id') = '" +
                    id + "' AND ChangesType = 2")
                .FirstOrDefaultAsync();
        }

        public IEnumerable<TrackDto> GetAllTracks(TrackFilterViewModel model, out int count)
        {
            IQueryable<ChangeInfo> tracks = Context.ChangeInfos
                .Include(e => e.User);

            tracks = model.EntityName != null && model.EntityName.Any()
                ? tracks.Where(x => model.EntityName.Contains(x.EntityName))
                : tracks;

            tracks = model.ChangesType != null && model.ChangesType.Any()
                ? tracks.Where(x => model.ChangesType.Contains(x.ChangesType))
                : tracks;

            tracks = (model.DateFrom != null && model.DateFrom.Value != DateTime.MinValue)
                ? tracks.Where(x => x.Time >= model.DateFrom.Value)
                : tracks;

            tracks = (model.DateTo != null && model.DateTo.Value != DateTime.MinValue)
                ? tracks.Where(x => x.Time <= model.DateTo.Value)
                : tracks;

            count = tracks.Count();

            var result = tracks.OrderBy(x => x.Time)
                .Skip((model.Page - 1) * model.PageSize)
                .Take(model.PageSize)
                .ToList();

            return Mapper.Map<IEnumerable<TrackDto>>(result);
        }

        public IEnumerable<EntityNamesDto> GetDistinctNames()
        {
            var entityNames = Context.ChangeInfos
                .Select(x => x.EntityName).Distinct().Select(x => new EntityNamesDto
                {
                    EntityName = x, Id = Guid.NewGuid(),
                });

            return entityNames;
        }
    }
}
