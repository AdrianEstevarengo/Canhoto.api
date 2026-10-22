using System;

namespace CanhotoBackEndSharp.Dtos
{
    public class SlaInfoDto
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Violated { get; set; }
        public int DaysLate { get; set; }
    }
}
