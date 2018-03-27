﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HOK.MissionControl.Core.Schemas
{
    /// <summary>
    /// Class for string Shared Parameter File Location.
    /// </summary>
    public class SharedParameterMonitor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string monitorId { get; set; } = "";
        public string monitorName { get; set; } = "";
        public string description { get; set; } = "";
        public string addInName { get; set; } = "";
        public string filePath { get; set; } = "";
        public bool isMonitorOn { get; set; } = false;
    }

    /// <summary>
    /// Class posted to MongoDB when user overrides any of the DTM Tools.
    /// </summary>
    public class CategoryTrigger
    {
        public string categoryName { get; set; } = "";
        public string description { get; set; } = "";
        public bool isEnabled { get; set; } = false;
        public bool locked { get; set; } = false;
        public string modifiedBy { get; set; } = "";
        public DateTime modified { get; set; } = DateTime.UtcNow;
    }

    /// <summary>
    /// Class wrapper around most of the category based updaters.
    /// </summary>
    public class ProjectUpdater
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string updaterId { get; set; } = "";
        public string updaterName { get; set; } = "";
        public string description { get; set; } = "";
        public string addInId { get; set; } = "";
        public string addInName { get; set; } = "";
        public bool isUpdaterOn { get; set; } = false;
        public List<CategoryTrigger> CategoryTriggers { get; set; } = new List<CategoryTrigger>();
        public UserOverrides userOverrides { get; set; }
    }

    /// <summary>
    /// Class holding all different possible user overrides for health checks.
    /// </summary>
    public class UserOverrides
    {
        public DimensionValueCheck dimensionValueCheck { get; set; }
        public FamilyNameCheck familyNameCheck { get; set; }
    }

    /// <summary>
    /// Override for Family Name.
    /// </summary>
    public class FamilyNameCheck
    {
        public string description { get; set; }
        public List<string> values { get; set; } = new List<string>();
    }

    /// <summary>
    /// Override for Dimension Values.
    /// </summary>
    public class DimensionValueCheck
    {
        public string description { get; set; }
        public List<string> values { get; set; } = new List<string>();
    }

    /// <summary>
    /// Main Configuration class.
    /// </summary>
    public class Configuration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string name { get; set; } = "";
        public List<RvtFile> files { get; set; } = new List<RvtFile>();
        public string sheetDatabase { get; set; } = "";
        public SharedParameterMonitor sharedParamMonitor { get; set; }
        public List<ProjectUpdater> updaters { get; set; } = new List<ProjectUpdater>();
    }
}
