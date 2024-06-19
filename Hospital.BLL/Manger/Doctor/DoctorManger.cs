using Hospital.BLL.Dtos;
using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class DoctorManger:IDoctorManger
    {
        private readonly IDoctorRepo db;
        private readonly IHopitalRepo hopitalDb;
        private readonly IDepartmentRepo depratmentDb;

        public DoctorManger( IDoctorRepo db ,IBookingRepo book, IHopitalRepo hopitalDb, IDepartmentRepo depratmentDb)
        {
            this.db = db;
            this.hopitalDb = hopitalDb;
            this.depratmentDb = depratmentDb;
        }

        private List<DoctorReadDto> returnLisOfDoctor(List<Doctor> Doctors)


        {
            return Doctors.Select(d => new DoctorReadDto
            {
                Id = d.Id,
                Name = d.Name,
                ProfilePic = d.ProfilePic,
                Deptname = d.Department?.Name ?? " ",
                description = d.description,
                price = d.price,
                Hosptialname = d.Department?.Hosptial?.Name ?? " "

            }).ToList();
        }
        public List<DoctorReadDto> GetAllDoctor()
        {
            var doctors = db.GetAll(d=>d.Department);

            return doctors.Select(d=> new DoctorReadDto
            {
                Id = d.Id,  
                Name = d.Name,  
                ProfilePic= d.ProfilePic,   
                Deptname=d.Department.Name,
                description=d.description,
                price=d.price,

            }).ToList();
        }

        public DoctorReadDto GetDoctorById(string id)
        {
            var doctor = db.GetByIdWithInclude(e => e.Id == id, d=>d.Department);
            if(doctor==null)
            {
                return null;
            }
            return new DoctorReadDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                ProfilePic = doctor.ProfilePic,
                Deptname = doctor.Department.Name,
                description = doctor.description,
                price = doctor.price,

            };

        }

        public List<DoctorBookIndayDto> GetDoctorBookInDay(string id)
        {
            DateTime currentDate = DateTime.Now.Date;
            var doctor = db.GetByIdWithInclude(d => d.Id == id, t => t.Bookings);
            var doclist = doctor.Bookings.ToList();
            var daylist = doclist.Where(e => e.DateOfBook.Equals(currentDate.Date)).ToList();
            if(daylist==null)
            {
                return null;
            }
            return  daylist.Select(d=>new DoctorBookIndayDto
            {
                patID=d.patId,
                patName=d.PatName,
                status=d.status,
                dateOfBook=d.DateOfBook.DayOfWeek.ToString(),
                timeOfBook=d.TimeOfBook

            }).ToList();    

        }

        public List<DoctorReadDto> GetAllDoctor(string hopspitlaName, string DeptName, string Doctorname)
        {
            if (hopspitlaName != null && DeptName != null && Doctorname != null)
            {
                var hopspital = hopitalDb.GetAll(h => h.Departments).Where(h => h.Name.Equals(hopspitlaName)).FirstOrDefault();

                var dept = hopspital.Departments.Where(d => d.Name.Equals(DeptName)).FirstOrDefault();

                var alldoctors = depratmentDb.GetByIdWithInclude(d => d.Id == dept.Id, doctor => doctor.Doctors).Doctors.ToList();
                var searchedDoctor = alldoctors.Where(doctor => doctor.Name.StartsWith(Doctorname)).ToList();

                return returnLisOfDoctor(searchedDoctor);

            }
            else if (hopspitlaName == null && DeptName == null && Doctorname == null)
            {
                return GetAllDoctor();
            }
            else if (hopspitlaName == null && DeptName != null && Doctorname != null)
            {


                var depts = depratmentDb.GetAll(dept => dept.Doctors).Where(d => d.Name == DeptName).ToList();

                var allDoctors = depts.SelectMany(d => d.Doctors).ToList();

                var searchDocor = allDoctors.Where(d => d.Name.StartsWith(Doctorname)).ToList();

                return returnLisOfDoctor(searchDocor);

            }
            else if (hopspitlaName != null && DeptName == null && Doctorname != null)
            {

                var depts = depratmentDb.GetAll(dept => dept.Hosptial, dept => dept.Doctors).Where(dept => dept.Hosptial.Name == hopspitlaName).ToList();

                var allDoctors = depts.SelectMany(d => d.Doctors).ToList();

                var searchDocor = allDoctors.Where(d => d.Name.StartsWith(Doctorname)).ToList();

                return returnLisOfDoctor(searchDocor);
            }
            else if (hopspitlaName != null && DeptName != null && Doctorname == null)
            {
                var depts = depratmentDb.GetAll(dept => dept.Hosptial, dept => dept.Doctors).Where(dept => dept.Hosptial.Name == hopspitlaName && dept.Name == DeptName).ToList();

                var allDoctor = depts.SelectMany(d => d.Doctors).ToList();
                return returnLisOfDoctor(allDoctor);
            }
            else if (hopspitlaName != null && DeptName == null && Doctorname == null)
            {
                var depts = depratmentDb.GetAll(dept => dept.Hosptial, dept => dept.Doctors).Where(dept => dept.Hosptial.Name == hopspitlaName).ToList();
                var allDoctor = depts.SelectMany(d => d.Doctors).ToList();
                return returnLisOfDoctor(allDoctor);
            }
            else if (hopspitlaName == null && DeptName == null && Doctorname != null)
            {
                var doctors = db.searchByName(Doctorname).ToList();
                if (doctors == null)
                {
                    return null;
                }
                else
                {

                    return returnLisOfDoctor(doctors);


                }




            }
            else if (hopspitlaName == null && DeptName != null && Doctorname == null)
            {
                var doctors = db.GetAll(doc => doc.Department).Where(d => d.Department.Name == DeptName).ToList();
                return returnLisOfDoctor(doctors);
            }

            else
            {
                return null;
            }

        }
    }
}
