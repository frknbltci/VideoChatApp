using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chat.CORE.Entities;
using chat.DTO.EEntity;

namespace chat.SERVICES.Services.Customer
{
        public class CustomerUserService : ICustomerUserService
        {

            private readonly IGenericRepository<CORE.Entities.Customer> _customerRepository;
            private readonly IUnitofWork _uow;

        private readonly IGenericRepository<CORE.Entities.Status> _statusRepository;
            // private EAdminUserDTO _adminUserDTO;

            public CustomerUserService(UnitofWork uow)
            {
                _uow = uow;
                _customerRepository = _uow.GetRepository<CORE.Entities.Customer>();
                _statusRepository = _uow.GetRepository<CORE.Entities.Status>();
            }

        public bool addBtPrice(int ID, int BtPrice)
        {
            try
            {
                var updateCus = _customerRepository.Find(ID);
                updateCus.BtPrice = updateCus.BtPrice + BtPrice;
                _uow.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }

        public bool addCustomer(CCustomerDTO data)
        {
            try
            {
                chat.CORE.Entities.Customer newCus = new chat.CORE.Entities.Customer()
                {
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = data.Pass,
                    GenderChoiceID=2,
                    GenderID=1,
                    IsActive=false,
                    StatusID=2,
                    ContractAcceptance=true,
                    ImageURL="/Areas/Assets/CustomerImg/men.png",
                };

                _customerRepository.Insert(newCus);
                
            }
            catch (Exception)
            {

                return false;
            }

            _uow.SaveChanges();
            return true;
        }

        public bool changeStatus(int? statusId, int? cusId)
        {
            if (statusId == null || cusId == null)
            {
                return false;
            }
            else
            {
                try
                {
                    var updateData = _customerRepository.GetAll().Where(x => x.ID == cusId).SingleOrDefault();

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

        public CustomerProfileDTO cusProfileEdit(int? id)
        {
            var statusList= _statusRepository.GetAll().ToList();

            var customer = (from c in _customerRepository.GetAll()
                            where c.ID == id
                            select new CustomerProfileDTO
                            {
                             
                                Email = c.Email,  
                                ImageUrl = c.ImageURL,               
                                Password = c.Password,
                                StatusID = c.StatusID,
                                UserName = c.UserName,
                                BtPrice=c.BtPrice,
                                

                            }).SingleOrDefault();

            customer.StatusList = statusList;

            return customer;
        }

        public void decreaseBtPrice(int price,int cusId)
        {
            var updateCus=_customerRepository.Find(cusId);
            updateCus.BtPrice = updateCus.BtPrice - price;
           
            _uow.SaveChanges();
        }

        public List<CORE.Entities.Customer> getCusList()
        {
            return _customerRepository.GetAll().ToList();
        }

        public bool Update(CustomerProfileDTO data)
        {
            try
            {
                var updateData = _customerRepository.GetAll().Where(x => x.ID == data.ID).SingleOrDefault();
                updateData.UserName = data.UserName;
                updateData.StatusID = data.StatusID;
                updateData.ImageURL = data.ImageUrl;
                updateData.Password = data.Password;
                updateData.Email = data.Email;
            }
            catch (Exception)
            {
                return false;
            }

            _uow.SaveChanges();
            return true;

        }

        public bool updateAdminCustomer(CORE.Entities.Customer gelen)
        {

            try
            {
                var updateData = _customerRepository.GetAll().Where(x => x.ID == gelen.ID).SingleOrDefault();
                updateData.UserName = gelen.UserName;
                updateData.BtPrice = gelen.BtPrice;
                updateData.Email = gelen.Email;
                updateData.Password = gelen.Password;
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
                var updateData = _customerRepository.Find(ID);

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

        CORE.Entities.Customer ICustomerUserService.getCustomerInfo(string Email, string Password)
        {
            if (Email == null || Password == null)
            {
                return null;
            }
            else
            {
                var customer = _customerRepository.GetAll().Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return customer;
                }
            }
        }


        public bool UpdateIsStatus(int ID)
        {
            try
            {
                var updateData = _customerRepository.Find(ID);

                if (updateData.StatusID == 1)
                {
                    updateData.StatusID=2;
                }
                else
                {
                    updateData.StatusID = 2;
                }
            }
            catch (Exception)
            {
                return false;
            }

            _uow.SaveChanges();
            return true;

        }


    }
}
