﻿using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TravelToBackend.Data;
using TravelToBackend.Dto;
using TravelToBackend.Interfaces;
using TravelToBackend.Mapper;
using TravelToBackend.Models;
namespace TravelToBackend.Repository
{
    public class TurebiRepository : ITurebiIepository
    {
        private readonly AppDataContext _context;
        public TurebiRepository(AppDataContext context)
        {
            _context = context;
        }

        public List<TurebiDto> GetAll()
        {
            ;
            var turebidto = _context.Turebi.
                Select(x => ToTurebiDtoMap.ToTurebiDto(x)).ToList(); 
            return turebidto;

        }
        public TurebiDto Get_Turi(int id)
        {
            var turi = _context.Turebi.FirstOrDefault(x => x.id == id);
            return ToTurebiDtoMap.ToTurebiDto(turi);
        }
        public bool Turi_Exists(int id)
        {
            var exists = _context.Turebi.FirstOrDefault(x=>x.id == id);
            if (exists != null)
            {
                return true;
            }
            return false;
        }

        public bool Company_exists_by_company_id(int? company_id)
        {
            var exists = _context.Turebi.FirstOrDefault(x=>x.Company_Id == company_id);
            if (exists != null) { 
            return true;
            }
            return false;
        }

        public bool Company_Exists_by_turi_id(int turi_id)
        {
            var exists = _context.Turebi.Include("Company").FirstOrDefault(x=>x.id==turi_id).Company;
            if (exists != null) {
                return true;
            }
            return false;
        }
        public List<CompanyDto> Get_All_Companies()
        {
            return _context.Companiebi.Select(x=>ToCompanyDto.ToCompanydto(x)).ToList();
        }
        public CompanyDto Get_Company_by_company_id(int company_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Companiebi.FirstOrDefault(x => x.Company_Id == company_id));
        }

        public CompanyDto Get_Company_by_turi(int turi_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Turebi.Include("Company").FirstOrDefault(x=>x.id==turi_id).Company);

        }
        public Turebi Create(TurebiDto turebidto)
        {

         var turi=ToTurebiFromDto.ToTurebi(turebidto);   
         _context.Add(turi);
            _context.SaveChanges();
            return turi;
        }
        public TurebiDto Update(int id, TurebiDto value)
        {
            var turi = _context.Turebi.FirstOrDefault(x=>x.id==id);
            turi.Name = value.Name;
            turi.Price = value.Price;
            turi.image_name= value.image_name;
            if (Company_exists_by_company_id(value.Company_Id))
            {
                turi.Company_Id = value.Company_Id;

            }
            turi.Description = value.Description;
            _context.Update(turi);
            _context.SaveChanges();
            return ToTurebiDtoMap.ToTurebiDto(turi);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
     

       
    
       
    }
}
