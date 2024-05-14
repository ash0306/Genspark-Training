﻿using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Exceptions;

namespace ClinicAPI.Services
{
    public class DoctorBasicService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorBasicService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            var doctors = (await _repository.Get()).ToList().FindAll(d => d.Speciality == speciality);
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<int> UpdateDoctorExperience(int id, int experience)
        {
            var doctor = await _repository.Get(id);
            if (doctor == null)
                throw new NoSuchDoctorException();
            doctor.Experience = experience;
            var updatedDoctor = await _repository.Update(doctor);
            return updatedDoctor.Id;
        }
    }
}
