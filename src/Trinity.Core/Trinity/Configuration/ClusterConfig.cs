﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Trinity.Configuration;
using Trinity.Diagnostics;
using Trinity.Network;
using Trinity.Utilities;
namespace Trinity
{
    public class ClusterConfig
    {
        #region Fields
        private string configFile;
        XMLConfig xml_config;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for compatibility only
        /// </summary>
        /// <param name="xmlConfig"></param>
        private ClusterConfig(string xmlConfig)
        {
            Servers = new List<AvailabilityGroup>();
            Proxies = new List<AvailabilityGroup>();
            configFile = xmlConfig;
            if (!File.Exists(xmlConfig))
                return;
            xml_config = new XMLConfig(configFile);
            _LegacyLoadConfig();
        }

        internal static ClusterConfig _LegacyLoadClusterConfig(string xmlConfig)
        {
            return new ClusterConfig(xmlConfig);
        }

        internal ClusterConfig() : this(new XElement(ConfigurationConstants.Tags.CLUSTER)) { }

        internal ClusterConfig(XElement config)
        {
            var IdAttr = config.Attribute(ConfigurationConstants.Attrs.ID);
            Id = IdAttr != null ? IdAttr.Value : null;

            var RunningModeAttr = config.Attribute(ConfigurationConstants.Attrs.RUNNINGMODE);
            if (RunningModeAttr != null && Enum.TryParse<RunningMode>(RunningModeAttr.Value, out var mode))
            {
                this.RunningMode = mode;
            }

            var serverEntries = config.Elements().Where(_ => _.Name == ConfigurationConstants.Tags.SERVER);
            var proxyEntries = config.Elements().Where(_ => _.Name == ConfigurationConstants.Tags.PROXY);

            int server_count = serverEntries.Count();
            int proxy_count = proxyEntries.Count();
            int server_with_agid_count = serverEntries.Where(_ => _.Attribute(ConfigurationConstants.Attrs.AVAILABILITY_GROUP) != null).Count();
            int proxy_with_agid_count = proxyEntries.Where(_ => _.Attribute(ConfigurationConstants.Attrs.AVAILABILITY_GROUP) != null).Count();

            if (server_count != server_with_agid_count && server_with_agid_count != 0)
            {
                throw new TrinityConfigException("Not all servers have " + ConfigurationConstants.Attrs.AVAILABILITY_GROUP + " attributes.");
            }

            if (proxy_count != proxy_with_agid_count && proxy_with_agid_count != 0)
            {
                throw new TrinityConfigException("Not all proxies have " + ConfigurationConstants.Attrs.AVAILABILITY_GROUP + " attributes.");
            }

            int server_ag_id = 0;
            int proxies_ag_id = 0;

            Servers = serverEntries
                .GroupBy(_ =>
                {
                    var attr = _.Attribute(ConfigurationConstants.Attrs.AVAILABILITY_GROUP);
                    if (attr != null) return attr.Value;
                    else return (server_ag_id++).ToString();
                })
                .Select(_ => new AvailabilityGroup(_.Key, _.Select(xelem => new ServerInfo(xelem))))
                .ToList();

            Proxies = proxyEntries
                .Where(_ => _.Name == ConfigurationConstants.Tags.PROXY)
                .GroupBy(_ =>
                {
                    var attr = _.Attribute(ConfigurationConstants.Attrs.AVAILABILITY_GROUP);
                    if (attr != null) return attr.Value;
                    else return (proxies_ag_id++).ToString();
                })
                .Select(_ => new AvailabilityGroup(_.Key, _.Select(xelem => new ServerInfo(xelem))))
                .ToList();
        }
        #endregion

        #region Property
        public string Id { get; private set; }
        public List<AvailabilityGroup> Servers { get; private set; }
        public List<AvailabilityGroup> Proxies { get; private set; }

        /// <summary>
        /// Get all Server instance
        /// </summary>
        public List<ServerInfo> AllServerInstances
        {
            get { return Servers.SelectMany(_ => _.Instances).ToList(); }
        }
        /// <summary>
        /// Get all Proxy instance
        /// </summary>
        public List<ServerInfo> AllProxyInstances
        {
            get { return Proxies.SelectMany(_ => _.Instances).ToList(); }
        }
        /// <summary>
        /// Gets a list of IPEndPoints corresponding to all the server instances.
        /// </summary>
        public List<IPEndPoint> AllServerIPEndPoints
        {
            get
            {
                return Servers.SelectMany(_ => _.Instances
                        .Select(instance => instance.EndPoint))
                        .ToList();
            }
        }

        /// <summary>
        /// Gets a list of IPEndPoints corresponding to all the proxy instances.
        /// </summary>
        public List<IPEndPoint> AllProxyIPEndPoints
        {
            get
            {
                return Proxies.SelectMany(_ => _.Instances
                        .Select(instance => instance.EndPoint))
                        .ToList();
            }
        }

        /// <summary>
        /// Gets the listening port of the current server.
        /// </summary>
        public int ListeningPort
        {
            get
            {
                switch (RunningMode)
                {
                    case RunningMode.Server:
                        return ServerPort;
                    case RunningMode.Proxy:
                        return ProxyPort;
                    default:
                        return TrinityConfig.InvalidPort;
                }
            }
        }

        /// <summary>
        /// Gets the port of current server.
        /// </summary>
        public int ServerPort
        {
            get
            {
                var instance = GetMyServerInfo();
                if (instance != null)
                {
                    return instance.Port;
                }
                return TrinityConfig.DefaultServerPort;
            }
        }

        /// <summary>
        /// Gets the port of current proxy.
        /// </summary>
        public int ProxyPort
        {
            get
            {
                var instance = GetMyProxyInfo();
                if (instance != null)
                {
                    return instance.Port;
                }
                return TrinityConfig.DefaultProxyPort;
            }
        }

        /// <summary>
        /// Represents the running mode of the current cluster configuration.
        /// </summary>
        public RunningMode RunningMode { get; internal set; }
        #endregion

        /// <summary>
        /// Gets the ServerInfo object of current server and it represents the specific information on the current server.
        /// </summary>
        /// <returns></returns>
        internal ServerInfo GetMyServerInfo()
        {
            for (int i = 0; i < Servers.Count; i++)
            {
                foreach (var instance in Servers[i].Instances)
                {
                    if (instance.AssemblyPath != null)
                    {
                        if (IPAddressComparer.IsLocalhost(instance.HostName) && 
                            FileUtility.ComparePath(instance.AssemblyPath, Global.MyAssemblyPath))
                        {
                            return instance;
                        }
                    }
                }
            }

            for (int i = 0; i < Servers.Count; i++)
            {
                foreach (var instance in Servers[i].Instances)
                {
                    if (IPAddressComparer.IsLocalhost(instance.HostName))
                        return instance;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the ServerInfo object of current server and it represents the specific information on the current proxy.
        /// </summary>
        /// <returns></returns>
        internal ServerInfo GetMyProxyInfo()
        {
            for (int i = 0; i < Proxies.Count; i++)
            {
                foreach (var instance in Proxies[i].Instances)
                {
                    if (instance.AssemblyPath != null)
                    {
                        if (IPAddressComparer.IsLocalhost(instance.HostName) && 
                            FileUtility.ComparePath(instance.AssemblyPath, Global.MyAssemblyPath))
                        {
                            return instance;
                        }
                    }
                }

                foreach (var instance in Proxies[i].Instances)
                {
                    if (IPAddressComparer.IsLocalhost(instance.HostName))
                        return instance;
                }
            }
            return null;
        }

        /// <summary>
        /// Return the current configuration information.
        /// </summary>
        /// <returns></returns>
        internal string OutputCurrentConfig()
        {
            CodeWriter cw = new CodeWriter();
            cw.WL();
            cw.WL("*****************************************************");
            cw.WL();

            #region cw.WL("Protocol.Servers: ");
            cw.WL("ServerCount: {0}", Servers.Count);

            foreach (var server in Servers)
            {
                foreach (var instance in server.Instances)
                {
                    cw.WL("    {0}:{1}", instance.HostName, instance.Port);
                }
            }
            #endregion

            #region cw.WL("Protocol.Proxies: ");
            cw.WL("ProxyCount: {0}", Proxies.Count);
            foreach (var proxy in Proxies)
            {
                foreach (var instance in proxy.Instances)
                {
                    cw.WL("    {0}:{1}", instance.HostName, instance.Port);
                }
            }
            #endregion

            cw.WL();
            cw.WL("*****************************************************");
            cw.WL();
            return cw.ToString();
        }

        private void _LegacyLoadConfig()
        {
            try
            {
                Servers.Clear();
                Servers.AddRange(_LegacyGetAvailabilityGroupList(xml_config, "Servers", "Server", "ServerId"));

                Proxies.Clear();
                Proxies.AddRange(_LegacyGetAvailabilityGroupList(xml_config, "Proxies", "Proxy", "ProxyId"));
            }
            catch (Exception e)
            {
                Log.WriteLine(LogLevel.Error, "There are errors in your configuration file.");
                Log.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Obtain a list of AvailabilityGroup from XML config.
        /// </summary>
        private IEnumerable<AvailabilityGroup> _LegacyGetAvailabilityGroupList(XMLConfig config, string xml_section_name, string xml_server_info_entry_name, string xml_agroup_id_attribute_name)
        {
            var server_entry_list = config.GetEntries(xml_section_name, xml_server_info_entry_name);
            Dictionary<string, List<ServerInfo>> id_infolist_dict = new Dictionary<string, List<ServerInfo>>();
            for (int i = 0; i < server_entry_list.Count; i++)
            {
                var str_ip_endpoint = server_entry_list[i].Value;
                string[] parts = str_ip_endpoint.Split(new char[] { ':' });

                Dictionary<string, string> pvs = server_entry_list[i].Attributes().ToDictionary(attr => attr.Name.ToString(), attr => attr.Value);

                string assemblyPath = null;
                string Id = null;
                LogLevel loggingLevel = LoggingConfig.c_DefaultLogLevel;
                string storageRoot = null;

                if (pvs.ContainsKey(ConfigurationConstants.Attrs.LEGACY_ASSEMBLY_PATH))
                    assemblyPath = FileUtility.CompletePath(pvs[ConfigurationConstants.Attrs.LEGACY_ASSEMBLY_PATH], false);

                if (pvs.TryGetValue(ConfigurationConstants.Attrs.STORAGE_ROOT, out storageRoot))
                    storageRoot = storageRoot.Trim();

                if (pvs.ContainsKey(ConfigurationConstants.Attrs.LOGGING_LEVEL))
                    loggingLevel = (LogLevel)Enum.Parse(typeof(LogLevel), pvs[ConfigurationConstants.Attrs.LOGGING_LEVEL], true);

                if (pvs.TryGetValue(xml_agroup_id_attribute_name, out Id))
                    Id = Id.Trim();
                else
                    Id = i.ToString(CultureInfo.InvariantCulture);

                ServerInfo si = ServerInfo._LegacyCreateServerInfo(
                        hostName: parts[0].Trim(),
                        port: int.Parse(parts[1]),
                        //httpPort: TrinityConfig.HttpPort,
                        assemblyPath: assemblyPath,
                        availabilityGroup: Id,
                        storageRoot: storageRoot,
                        loggingLevel: loggingLevel.ToString());


                List<ServerInfo> list = null;
                if (!id_infolist_dict.TryGetValue(si.Id, out list))
                {
                    list = new List<ServerInfo>();
                    id_infolist_dict.Add(si.Id, list);
                }
                list.Add(si);
            }

            return id_infolist_dict.Select(_ => new AvailabilityGroup(_.Key, _.Value.Select(si => (ServerInfo)si)));
        }
    }

}
