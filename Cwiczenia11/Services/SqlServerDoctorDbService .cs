using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Services
{    public class SqlServerDoctorDbService : IDoctorDbService
    {
        private readonly ClinicDbContext _dbContext;

        public SqlServerDoctorDbService(ClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            var doctorEntity = await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();
            return doctorEntity.Entity;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _dbContext.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> RemoveDoctor(int id)
        {
            var doctor = await GetDoctor(id);
            if (doctor == null)
                return null;
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(Doctor newDoctor)
        {
            var currentDoctor = await GetDoctor(newDoctor.IdDoctor);
            if (currentDoctor == null)
                return null;

            if (newDoctor.FirstName != null)
                currentDoctor.FirstName = newDoctor.FirstName;
            if (newDoctor.LastName != null)
                currentDoctor.LastName = newDoctor.LastName;
            if (newDoctor.Email != null)
                currentDoctor.Email = newDoctor.Email;

            _dbContext.Entry(currentDoctor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return newDoctor;
        }
    }
}
