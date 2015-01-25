using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompanyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompanyService.svc or CompanyService.svc.cs at the Solution Explorer and start debugging.
    public class CompanyService : ICompanyService
    {
        private InterviewPracticeEntities ctx = new InterviewPracticeEntities();

        public List<Company> GetAllCompanies()
        {
            return (from c in ctx.Companies select c).ToList();
        }

        public Company GetACompany(int id)
        {
            return (from c in ctx.Companies where c.Id == id select c).FirstOrDefault();
        }

        public List<Emplyee> GetAllEmployees()
        {
            return (from e in ctx.Emplyees select e).ToList();
        }

        public Emplyee GetEmployee(int id)
        {
            return (from e in ctx.Emplyees select e).FirstOrDefault();
        }

        public List<Emplyee> GetEmployeesForACompany(int id)
        {
            return (from c in ctx.Companies
                    join ec in ctx.Emplyee_Company on c.Id equals ec.CompanyId
                    join e in ctx.Emplyees on ec.EmployeeId equals e.Id
                    where c.Id == id
                    select e).ToList();
        }
    }
}
