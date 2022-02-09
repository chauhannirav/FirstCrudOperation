using FirstCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstCrudOperation.Controllers
{
    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetAllEmployees()
        {
            IList<Employee> employees = null;

            using (var ctx = new DemoEntities())
            {
                employees = ctx.tblEmployee.Select(e => new Employee()
                            {
                                ID = e.ID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Qualification=e.Qualification,
                                Experience=e.Experience,
                                JoiningDate= (DateTime)e.JoiningDate,
                                ExpectedSal=e.ExpectedSal
                }).ToList<Employee>();
            }

            if (employees.Count == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }
       
        public IHttpActionResult PostNewEmployee([FromBody]Employee Emp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new DemoEntities())
            {
               
                ctx.tblEmployee.Add(new tblEmployee()
                {
                    ID = Emp.ID,
                    FirstName = Emp.FirstName,
                    LastName = Emp.LastName,
                    Qualification = Emp.Qualification,
                    Experience = Emp.Experience,
                    JoiningDate = (DateTime)Emp.JoiningDate,
                    ExpectedSal = Emp.ExpectedSal
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
        public HttpResponseMessage Put(int id, Employee employee)
        {
            try
            {
                using (DemoEntities entities = new DemoEntities())
                {
                    var entity = entities.tblEmployee.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Qualification = employee.Qualification;
                        entity.Experience = employee.Experience;
                        entity.ExpectedSal = employee.ExpectedSal;
                        entity.JoiningDate = employee.JoiningDate;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (DemoEntities entities = new DemoEntities())
                {
                    var entity = entities.tblEmployee.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.tblEmployee.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}