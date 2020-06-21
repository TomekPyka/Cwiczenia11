using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia11.Services
{    public interface IDoctorDbService
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> GetDoctor(int id);
        public Task<Doctor> AddDoctor(Doctor doctor);
        public Task<Doctor> UpdateDoctor(Doctor doctor);
        public Task<Doctor> RemoveDoctor(int id);
    }
}