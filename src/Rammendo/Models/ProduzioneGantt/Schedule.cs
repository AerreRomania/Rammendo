using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammendo.Models.ProduzioneGantt
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public string Barcode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ProductionStartTime { get; set; }
        public DateTime ProductionEndTime { get; set; }
        public DateTime DelayStartTime { get; set; }
        public DateTime DelayEndTime { get; set; }
        public int FixedQty { get; set; }

        public int ProdQty { get; set; }
        public double QtyH { get; set; }
        public string Line { get; set; }

        public Schedule(int id, string op, string barcode,DateTime startTime, DateTime endTime, DateTime prodstart, DateTime prodEnd, DateTime delStart,
            DateTime delEnd, int fixedQty, int prodQty, double qtyH, string line)
        {
            Id = id;
            Operator = op;
            Barcode = barcode;
            StartTime = startTime;
            EndTime = endTime;
            ProductionStartTime = prodstart;
            ProductionEndTime = prodEnd;
            DelayStartTime = delStart;
            DelayEndTime = delEnd;
            FixedQty = fixedQty;
            ProdQty = prodQty;
            QtyH = qtyH;
            Line = line;
        }
    }
}
