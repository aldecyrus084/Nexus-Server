using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nexus.Domain.Entities
{
    public class ClientPC
    {
        public Guid ClientPCId { get; private set; }
        public string MacAddress { get; private set; }
        public string IpAddress { get; private set; }
        public bool isVip { get; private set; } = false;
        public bool Is_Auto_Shutdown { get; private set; }
        public string Background_Image { get; private set; }
        public int? Credit { get; private set; }

        //Realtime monitoring
        public string? PcName { get; private set; }
        public TimeOnly? RemainingTime { get; private set; }
        public DateTime? DateInserted { get; private set; }
        public bool Is_Online { get; private set; }
        public Guid? LoginUser { get; private set; }
        public Customers Customer { get; private set; }
        public string? ClientVersion { get; private set; }
        public string? Ram { get; private set; }
        public string? CpuTemp { get; private set; }
        public string? Cpu_Usage { get; private set; }
        public string? Download_Speed { get; private set; }
        public string? Upload_Speed { get; private set; }
        public string? System_Details { get; private set; }


        protected ClientPC() { }

        public ClientPC(string macAddress, string ipAddress, string pcName, bool IsVip, bool is_Auto_Shutdown, string bgPath )
        {
            ClientPCId = Guid.NewGuid();
            MacAddress = macAddress;
            IpAddress = ipAddress;
            PcName = pcName;
            isVip = IsVip;
            Is_Auto_Shutdown = is_Auto_Shutdown;
            Background_Image = bgPath;
        }

        public void RealtimeStatus(string pcName, TimeOnly remainingTime, DateTime dateInserted, Guid loginUser, string clientversion, string ram, string cpuTemp, string cpuUsage, string download_speed, string upload_speed, string systemDetails )
        {
            PcName = pcName;
            RemainingTime = remainingTime;
            DateInserted = dateInserted;
            Is_Online = true;
            LoginUser = loginUser;
            ClientVersion = clientversion;
            Ram = ram;
            CpuTemp = cpuTemp;
            Cpu_Usage = cpuUsage;
            Download_Speed = download_speed;
            Upload_Speed = upload_speed;
            System_Details = systemDetails;
        }

        public void ShutDownClientPC()
        {
            Is_Online = false;
            RemainingTime = null;
            DateInserted = null;
            LoginUser = null;
            ClientVersion = null;
            Ram = null;
            CpuTemp = null;
            Cpu_Usage = null;
            Download_Speed = null;
            Upload_Speed = null;
        }

    }
}
