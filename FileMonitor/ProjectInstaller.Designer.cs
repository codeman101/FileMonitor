namespace FileMonitor
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileMonitorProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.FileMonitorServiceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // FileMonitorProcessInstaller1
            // 
            this.FileMonitorProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.FileMonitorProcessInstaller1.Password = null;
            this.FileMonitorProcessInstaller1.Username = null;
            // 
            // FileMonitorServiceInstaller1
            // 
            this.FileMonitorServiceInstaller1.DisplayName = "FileMonitor";
            this.FileMonitorServiceInstaller1.ServiceName = "FileMonitor";
            this.FileMonitorServiceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.FileMonitorServiceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FileMonitorServiceInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.FileMonitorProcessInstaller1,
            this.FileMonitorServiceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller FileMonitorProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller FileMonitorServiceInstaller1;
    }
}