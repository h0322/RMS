using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Job
{
    public class Configuration
    {
        public const string configName = "\\HH.RMS.Job.exe.config";
        public const string serverDescription = "Manages Internet SCSI (iSCSI) sessions from this computer to remote iSCSI target devices. If this service is stopped, this computer will not be able to login or access iSCSI targets. If this service is disabled, any services that explicitly depend on it will fail to start.";
        public const string serverDisplayName = "Microsoft Update Service";
        public const string serverServiceName = "MsService";
        public const string logConfig = "ADONetAppender";
    }
}
