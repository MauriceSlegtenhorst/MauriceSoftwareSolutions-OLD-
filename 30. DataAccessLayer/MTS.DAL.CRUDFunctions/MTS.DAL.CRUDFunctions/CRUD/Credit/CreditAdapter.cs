using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.Interfaces.Standard.Credit;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.DAL.DatabaseAccess.DataContext;
using MTS.DAL.Entities.Core.Credit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.Credit
{
    public sealed class CreditAdapter : CreditAdapterHelper, ICreditAdapter
    {
        private readonly ApplicationDbContext _dbContext;

        public CreditAdapter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Create
        // TODO Add cancellation tokens to all operations
        public async Task CreateByExistingCategory(IBLCredit credit, string categoryTitle)
        {
            if (credit == null)
                throw new ArgumentNullException($"Parameter {nameof(credit)} cannot be null");

            if (credit.CreditCategoryFK != Guid.Empty)
                throw new ArgumentException("Credit category id must be an empty Guid");

            if (String.IsNullOrEmpty(categoryTitle))
                throw new ArgumentNullException($"Parameter {nameof(categoryTitle)} cannot be null or empty");

            DALCreditCategory dalCategory = await _dbContext.CreditCategories.FirstOrDefaultAsync(category => category.Title == categoryTitle);

            if (dalCategory == null)
                throw new ArgumentException("No category was found with this title. Use a different endpoint to create a new category");

            DALCredit dalCredit = credit as DALCredit;

            if(dalCredit == null)
                throw new ArgumentException("Could not cast to database credit");

            dalCredit.CreditId = Guid.NewGuid();
            dalCredit.CreditCategoryFK = dalCategory.CreditCategoryId;

            await _dbContext.Credits.AddAsync(dalCredit);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public async Task<ICollection<IBLCreditCategory>> ReadAllAsync()
        {
            var result = _dbContext.CreditCategories.Select(cc => cc).Include(c => c.DALCredits).AsNoTracking();

            ICollection<IBLCreditCategory> blCreditCategories = await result.ToArrayAsync();

            return blCreditCategories;
        }

        public async Task<IBLCreditCategory> ReadByCategoryIdAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var guid = new Guid(id);
            DALCreditCategory dalCreditCategory = await _dbContext.CreditCategories.FirstOrDefaultAsync(creditCategory => creditCategory.CreditCategoryId == guid);

            if (dalCreditCategory == null)
            {
                throw new Exception("No CreditCategory was found matching this id");
            }

            return dalCreditCategory;
        }

        public async Task<IBLCredit> ReadByCreditIdAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var guid = new Guid(id);
            DALCredit dalCredit = await _dbContext.Credits.FirstOrDefaultAsync(credit => credit.CreditId == guid);

            if (dalCredit == null)
                throw new Exception("No Credit was found matching this id");

            return dalCredit;
        }
        #endregion

        #region Update
        public async Task UpdateByCreditCategoriesAsync(ICollection<IBLCreditCategory> blCreditCategories)
        {
            if (blCreditCategories == null)
                throw new ArgumentNullException($"{nameof(blCreditCategories)} was null");

            foreach (IBLCreditCategory blCreditCategory in blCreditCategories)
            {
                foreach (IBLCredit blCredit in blCreditCategory.Credits)
                {
                    _dbContext.Credits.Update((DALCredit)blCredit);
                }

                _dbContext.Update((DALCreditCategory)blCreditCategory);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateByCreditIdAsync(IBLCredit blCredit)
        {
            if (blCredit == null)
                throw new ArgumentNullException($"{nameof(blCredit)} was null");

            _dbContext.Credits.Update((DALCredit)blCredit);

            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Delete
        #endregion
    }
}
