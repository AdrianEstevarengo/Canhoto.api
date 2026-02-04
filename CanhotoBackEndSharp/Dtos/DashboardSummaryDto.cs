using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class DashboardSummaryDto
    {
        public int TotalEntregasHoje { get; set; }
        public int EntregasPendentes { get; set; }
        public int EntregasAtrasadas { get; set; }
        public int EntregasEntreguesHoje { get; set; }
        public double TaxaOnTime { get; set; }
        public int SlaViolationsCount { get; set; }
    }
}
