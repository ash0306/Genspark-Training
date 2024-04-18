﻿using AppointmentTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTrackerBLLibrary
{
    public interface IDoctorService
    {
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        List<Doctor> GetAllDoctors();
        Doctor UpdateDoctor(Doctor doctor);
        Doctor DeleteDoctor(int id);
    }
}