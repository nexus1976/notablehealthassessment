using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nh.health.domain.Entities;

namespace nh.health.domain.Aggregates
{
    public class DoctorScheduleAggregate
    {
        public Schedule? Schedule { get; set; }
        public Patient? Patient { get; set; }
    }
}
