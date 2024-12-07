﻿using CsvHelper.Configuration;
using leyadech.server.DTO;

namespace leyadech.server.Service
{
    public class RequestMap:ClassMap<HelpRequest>
    {
        public RequestMap()
        {
            Map(req => req.ApplicationId);
            Map(req => req.UserId);
            Map(req => req.HelpKind);
            Map(req => req.Description);
            Map(req => req.ApplicationDate);
            Map(req => req.IsRelevant);
            Map(req => req.Frequency);
            Map(req => req.UrgencyLevel);
            Map(req => req.Preferences).TypeConverter<ListToStringConverter>();
        }
    }
}
