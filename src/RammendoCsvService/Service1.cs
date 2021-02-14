using System.ServiceProcess;
using System.Timers;
using CsvImporter;

namespace RammendoCsvService
{
    public partial class Service1 : ServiceBase
    {
        private readonly Importer _importer = new Importer();
        private readonly Log Log = new Log();

        private Timer _timer = new Timer();

        public Service1() {
            InitializeComponent();
            _importer = new Importer();
        }

        protected override void OnStart(string[] args) {
            System.Threading.Thread trd =
            new System.Threading.Thread(new System.Threading.ThreadStart(InitTimer));

            trd.Start();
        }

        protected override void OnStop() {
            _timer.Enabled = false;
            Log.WriteLog(message: "Service has been stopped");
        }

        private void InitTimer() {
            Log.WriteLog(message: "Service has been started");

            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(_timer_Tick);
            _timer.Interval = 300000; //5min   //1.2e+6 20min check
            _timer.Enabled = true;
            _timer.Start();
        }

        private void _timer_Tick(object sender, ElapsedEventArgs elapsed) {
            _importer.Import();
        }
    }
}
