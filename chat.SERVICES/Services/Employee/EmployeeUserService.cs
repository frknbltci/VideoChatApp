using chat.DATA.GenericRepository;
using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chat.SERVICES.Interfaces.Employee;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;

namespace chat.SERVICES.Services.Employee
{
    public class EmployeeUserService : IEmployeeUserService
    {
        private readonly IGenericRepository<CORE.Entities.Employee> _employeeRepository;

        private readonly IGenericRepository<HairColors> _hairColorRepository;
        private readonly IGenericRepository<HairTypes> _hairTypesRepository;
        private readonly IGenericRepository<EyeColors> _eyeColorRepository;
        private readonly IGenericRepository<BodyTypes> _bodyRepository;
        private readonly IGenericRepository<Gender> _genderRepository;


        private readonly IUnitofWork _uow;
        public EmployeeUserService(UnitofWork uow)
        {
            _uow = uow;
            _employeeRepository = _uow.GetRepository<CORE.Entities.Employee>();
            _hairColorRepository = _uow.GetRepository<HairColors>();
            _hairTypesRepository = _uow.GetRepository<HairTypes>();
            _eyeColorRepository = _uow.GetRepository<EyeColors>();
            _bodyRepository = _uow.GetRepository<BodyTypes>();
            _genderRepository = _uow.GetRepository<Gender>();
        }

        public EmployeeProfileDTO empProfileEdit(int? id)
        {
          // KONTROL ATILMALI ? REDİRECT DENENDİ ACTİON DEĞİL NE YAPMAK GEREK ?  if (id!=null)
           
            var employee = (from e in _employeeRepository.GetAll()
                            where e.ID == id
                            select new EEmployeeDTO
                            {
                                BankName = e.BankName,
                                Email = e.Email,
                                FirstName = e.FirstName,
                                GenderID = e.GenderID,
                                IBAN = e.IBAN,
                                ImageURL = e.ImageURL,
                                IsActive = e.IsActive,
                                LastName = e.LastName,
                                NickName = e.NickName,
                                Password = e.Password,
                                StatusID = e.StatusID,
                                UserName = e.UserName,
                                About=e.About,
                                BodyTypeID=e.BodyTypeID,
                                EyeColorID=e.EyeColorID,
                                HairColorID=e.HairColorID,
                                HairTypeID=e.HairTypeID,
                                Weight=e.Weight,
                                Length=e.Length,
                                BirthDate=e.BirthDate
                                

                            }).SingleOrDefault();


            var hairColor = _hairColorRepository.GetAll().ToList();
            var hairTypes = _hairTypesRepository.GetAll().ToList();
            var eyeColors = _eyeColorRepository.GetAll().ToList();
            var bodyTypes = _bodyRepository.GetAll().ToList();
            var gender = _genderRepository.GetAll().ToList();


            var data = new EmployeeProfileDTO()
            {
                bodyTypesList = bodyTypes,
                employe = employee,
                eyeColorList = eyeColors,
                genderList = gender,
                hairColorList = hairColor,
                hairTypesList = hairTypes
            };

            return data;

            
        }

        public List<CORE.Entities.Employee> getEmployee()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public CORE.Entities.Employee getEmployeInfo(string Email, string Password)
        {
            if (Email==null || Password==null )
            {
                return  null;
            }
            else
            {
                return _employeeRepository.GetAll().Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
            }
            
        }

        public EmployeeProfileDTO getRegisInfo()
        {
            var hairColor = _hairColorRepository.GetAll().ToList();
            var hairTypes = _hairTypesRepository.GetAll().ToList();
            var eyeColors = _eyeColorRepository.GetAll().ToList();
            var bodyTypes = _bodyRepository.GetAll().ToList();
            var gender = _genderRepository.GetAll().ToList();


            EmployeeProfileDTO data = new EmployeeProfileDTO()
            {
                bodyTypesList=bodyTypes,
                eyeColorList=eyeColors,
                genderList=gender,
                hairColorList=hairColor,
                hairTypesList= hairTypes

            };

            return data;
        }

        public void Update(EEmployeeDTO data)
        {

            chat.CORE.Entities.Employee employee = _employeeRepository.GetAll().Where(x => x.Email == data.Email).FirstOrDefault();

            employee.About = data.About;
            employee.ImageURL = data.ImageURL;
            employee.BankName = data.BankName;
            employee.BirthDate = data.BirthDate;
            employee.BodyTypeID = data.BodyTypeID;
            employee.Email = data.Email;
            employee.EyeColorID = data.EyeColorID;
            employee.FirstName = data.FirstName;
            employee.GenderID = data.GenderID;
            employee.HairColorID = data.HairColorID;
            employee.HairTypeID = data.HairTypeID;
            employee.IBAN = data.IBAN;
            employee.LastName = data.LastName;
            employee.Length = data.Length;
            employee.NickName = data.NickName;
            employee.Password = data.Password;
            employee.UserName = data.UserName;
            employee.Weight = data.Weight;
            employee.IsActive = true;
            employee.StatusID = 1; // Sessiondan
            employee.Confirmation = data.Confirmation;
            _uow.SaveChanges();


            //chat.CORE.Entities.Employee eklenecekVeri = new chat.CORE.Entities.Employee()
            //{

            //    ImageURL = data.ImageURL,
            //    About = data.About,
            //    BankName = data.BankName,
            //    BirthDate = data.BirthDate,
            //    BodyTypeID = data.BodyTypeID,
            //    Email = data.Email,
            //    EyeColorID = data.EyeColorID,
            //    FirstName = data.FirstName,
            //    GenderID = data.GenderID,
            //    HairColorID = data.HairColorID,
            //    HairTypeID = data.HairTypeID,
            //    IBAN = data.IBAN,
            //    LastName = data.LastName,
            //    Length = data.Length,
            //    NickName = data.NickName,
            //    Password = data.Password,
            //    UserName = data.UserName,
            //    Weight = data.Weight,
            //    IsActive = true,
            //    StatusID=1 //Sessiondan

            //};


            // _employeeRepository.Update(eklenecekVeri);
            //  _uow.SaveChanges();

        }


        public bool addUser(EEmployeeDTO data)
        {
            try
            {
                chat.CORE.Entities.Employee emp = new chat.CORE.Entities.Employee()
                {
                    Weight = data.Weight,
                    BirthDate = data.BirthDate.Date,
                    Email = data.Email,
                    UserName = data.UserName,
                    NickName = data.NickName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    HairColorID = data.HairColorID,
                    EyeColorID = data.EyeColorID,
                    HairTypeID = data.HairTypeID,
                    BodyTypeID = data.BodyTypeID,
                    GenderID = 2,
                    StatusID = 2,
                    Password = data.Password,
                    ImageURL = "/Areas/Assets/ModelImg/women.png",
                    ContractAcceptance=true
                };

                _employeeRepository.Insert(emp);

                _uow.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public void updateStatus(int ID)
        {

            chat.CORE.Entities.Employee employee = _employeeRepository.GetAll().Where(x => x.ID ==ID).FirstOrDefault();
            employee.StatusID = 1;
            _uow.SaveChanges();

        }

        public bool updateAdminEmployee(CORE.Entities.Employee data)
        {
            try
            {
                var updateData = _employeeRepository.GetAll().Where(x => x.ID == data.ID).SingleOrDefault();
                updateData.UserName = data.UserName;
                updateData.Email = data.Email;
                updateData.Password = data.Password;
            }
            catch (Exception)
            {
                return false;
            }

            _uow.SaveChanges();
            return true;
        }

        public bool UpdateIsActive(int ID)
        {
            try
            {
                var updateData = _employeeRepository.Find(ID);

                if (updateData.IsActive == true)
                {
                    updateData.IsActive = false;
                }
                else
                {
                    updateData.IsActive = true;
                }
            }
            catch (Exception)
            {

                return false;
            }

            _uow.SaveChanges();
            return true;
        }

        public bool changeStatus(int? statusId, int? empId)
        {
            if (statusId==null || empId==null)
            {
                return false;
            }
            else
            {
                try
                {
                    var updateData = _employeeRepository.GetAll().Where(x => x.ID == empId).SingleOrDefault();

                    updateData.StatusID = (int)statusId;
                    _uow.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
          

            }



        }
    }
}
