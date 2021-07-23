using CWC.DAL.Entity;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Repository
{
    public interface IManageVendors
    {
        /// <summary>
        /// vendors Details
        /// </summary>
        /// <param name="vendors Details"></param>
        /// <returns></returns>
        Task<Tuple<long, bool>> AddNewVendor(Vendors model);
        Task<bool> UpdateVendorDetails(Vendors model);
        Task<List<VendorsResDTOs>> GetVendorList(int PageNumber, int PageSize);
        Task<Vendors> GetVendorDetailsById(int id);
        Task<bool> DeleteVendors(int Id, string name);
        Task<bool> ApprNewVendors(int Id);


    }
}
