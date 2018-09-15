using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;
using System.Diagnostics;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace FileMonitor
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            EventLogInstaller installer = FindInstaller(this.Installers);
            if (installer != null)
            {
                installer.Log = "FileMonitor"; // servie name for event log
            }
        }
        private EventLogInstaller FindInstaller(InstallerCollection installers)
        {
            foreach (Installer installer in installers)
            {
                if (installer is EventLogInstaller)
                {
                    return (EventLogInstaller)installer;
                }

                EventLogInstaller eventLogInstaller = FindInstaller(installer.Installers);
                if (eventLogInstaller != null)
                {
                    return eventLogInstaller;
                }
            }
            return null;
        }
        private void FileMonitorServiceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
			// this method was created when I double clicked it in the designer and although it's uncesssary deleting it breaks the progrsam
        }
    }
}
