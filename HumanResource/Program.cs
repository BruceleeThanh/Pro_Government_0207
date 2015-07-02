using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CORESYSTEM;
using DevExpress.LookAndFeel;
using System.Configuration;

namespace HumanResource
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");


            CORE.INIT(ConfigurationManager.AppSettings["SystemKey"].ToString());

            Application.Run(new frmLogin());
        }
    }
}
