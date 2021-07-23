using CWC.DAL.Context;
using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Implementation
{
    public class ManageVendorsService: IManageVendors
    {
        private readonly CWCContext _dbcontext;
        private readonly DapperContext _dacontext;

        public ManageVendorsService(CWCContext dbcontext, DapperContext context)
        {

            _dbcontext = dbcontext;
            _dacontext = context;
        }
        public async Task<Tuple<long, bool>> AddNewVendor(Vendors model)
        {
            if(model.IsNewApproved!=true)
            model.IsNewApproved = false;
            model.IsDeleted = false;
            model.AddedDate = DateTime.Now;
            await _dbcontext.Vendors.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
            return new Tuple<long, bool>(model.ID, true);

        }
        public async Task<bool> UpdateVendorDetails(Vendors model)
        {
            var vendor = await _dbcontext.Vendors.Where(v => v.ID == model.ID).FirstOrDefaultAsync();
            vendor.First_Name = model.First_Name;
            vendor.Last_Name = model.Last_Name;
            vendor.Contact_No = model.Contact_No;
            vendor.EmailID = model.EmailID;
            vendor.Address = model.Address;
            vendor.City = model.City;
            vendor.State = model.State;
            _dbcontext.Update(vendor);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<VendorsResDTOs>> GetVendorList(int PageNumber, int PageSize)
        {
            var vendors = await (from v in _dbcontext.Vendors.Where(p => p.IsDeleted == false)
                                  orderby v.ID descending
                                  select new VendorsResDTOs
                                  {
                                      ID = v.ID,
                                      First_Name=v.First_Name,
                                      Last_Name=v.Last_Name,
                                      Contact_No=v.Contact_No,
                                      EmailID=v.EmailID,
                                      City=v.City,
                                      State=v.State,
                                      IsNewApproved= v.IsNewApproved


                                  }).Skip((PageNumber - 1) * PageSize)
                                    .Take(PageSize).ToListAsync();

            return vendors;
        }
        public async Task<Vendors> GetVendorDetailsById(int id)
        {
            var vendor = await _dbcontext.Vendors.Where(v => v.ID == id).FirstOrDefaultAsync();
            return vendor;
        }
        public async Task<bool> DeleteVendors(int Id,string name)
        {
            var vendor = await _dbcontext.Vendors.Where(v => v.ID == Id).FirstOrDefaultAsync();
            vendor.IsDeleted = true;
            vendor.DeletedBy = name;
            _dbcontext.Entry(vendor).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

      public  async Task<bool> ApprNewVendors(int Id)
        {

            var vendor = await _dbcontext.Vendors.Where(v => v.ID == Id).FirstOrDefaultAsync();
            vendor.IsNewApproved = true;
            _dbcontext.Entry(vendor).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;

        }
    }
}
